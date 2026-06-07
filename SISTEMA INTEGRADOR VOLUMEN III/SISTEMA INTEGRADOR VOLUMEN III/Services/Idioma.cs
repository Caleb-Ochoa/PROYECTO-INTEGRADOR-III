using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III
{
    /// <summary>
    /// Sistema de traducción basado en un único archivo plano: traducciones.txt
    ///
    /// Formato de cada línea:
    ///   nombreControl|NombreFormulario|Texto en español|Text in English
    ///
    /// USO:
    ///   Idioma.Cargar("es");       // al iniciar el programa
    ///   Idioma.Aplicar(this);      // en el constructor de cada Form
    ///   Idioma.MostrarSelector(this); // desde el botón 🌐 de cualquier Form
    /// </summary>
    internal static class Idioma
    {
        public static string IdiomaActual { get; private set; } = "es";

        private static Dictionary<string, string> _textos = new();

        // ── Carga el archivo de traducciones ──────────────────────────────
        public static void Cargar(string codigoIdioma)
        {
            IdiomaActual = codigoIdioma;
            _textos.Clear();

            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Traducciones.txt");

            MessageBox.Show(ruta);

            if (!File.Exists(ruta))
            {
                MessageBox.Show(
                    $"No se encontró Traducciones.txt\nRuta: {ruta}",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (string linea in File.ReadAllLines(ruta, System.Text.Encoding.UTF8))
            {
                string l = linea.Trim();
                if (string.IsNullOrEmpty(l) || l.StartsWith("#")) continue;

                string[] p = l.Split('|');
                if (p.Length != 4) continue;

                // Clave: "Formulario|control"
                string clave = $"{p[1].Trim()}|{p[0].Trim()}";
                _textos[clave] = codigoIdioma == "en" ? p[3].Trim() : p[2].Trim();
            }
            
        }

        // ── Aplica el idioma a todos los controles de un Form ─────────────
        public static void Aplicar(Form form)
        {
            AplicarRecursivo(form, form.GetType().Name);
        }

        private static void AplicarRecursivo(Control ctrl, string nombreForm)
        {
            string clave = $"{nombreForm}|{ctrl.Name}";
            if (_textos.TryGetValue(clave, out string? texto))
            {
                switch (ctrl)
                {
                    case Button b: b.Text = texto; break;
                    case Label l: l.Text = texto; break;
                    case GroupBox g: g.Text = texto; break;
                    case CheckBox c: c.Text = texto; break;
                    case TabPage t: t.Text = texto; break;
                }
            }
            foreach (Control hijo in ctrl.Controls)
                AplicarRecursivo(hijo, nombreForm);
        }

        // ── Selector de idioma inline (sin formulario extra) ──────────────
        /// <summary>
        /// Muestra un pequeño popup bilingüe para elegir idioma.
        /// Llamar desde btnIdioma_Click en Login, RegistroAdmin y MenuPrincipal.
        /// </summary>
        public static void MostrarSelector(Form owner)
        {
            // Popup pequeño creado en código — no necesita .Designer.cs
            using Form popup = new Form
            {
                Text = "Idioma / Language",
                Size = new System.Drawing.Size(280, 130),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblTitulo = new Label
            {
                Text = "Seleccione el idioma / Select language:",
                AutoSize = false,
                Width = 260,
                Location = new System.Drawing.Point(10, 10),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            // Botón Español
            var btnEs = new Button
            {
                Text = "🇨🇴  Español",
                Size = new System.Drawing.Size(115, 38),
                Location = new System.Drawing.Point(10, 45),
                BackColor = IdiomaActual == "es"
                    ? System.Drawing.Color.SteelBlue
                    : System.Drawing.SystemColors.Control,
                ForeColor = IdiomaActual == "es"
                    ? System.Drawing.Color.White
                    : System.Drawing.SystemColors.ControlText,
                FlatStyle = FlatStyle.Flat
            };
            btnEs.FlatAppearance.BorderSize = 0;

            // Botón English
            var btnEn = new Button
            {
                Text = "🇺🇸  English",
                Size = new System.Drawing.Size(115, 38),
                Location = new System.Drawing.Point(145, 45),
                BackColor = IdiomaActual == "en"
                    ? System.Drawing.Color.SteelBlue
                    : System.Drawing.SystemColors.Control,
                ForeColor = IdiomaActual == "en"
                    ? System.Drawing.Color.White
                    : System.Drawing.SystemColors.ControlText,
                FlatStyle = FlatStyle.Flat
            };
            btnEn.FlatAppearance.BorderSize = 0;

            // Click Español
            btnEs.Click += (s, e) =>
            {
                Cargar("es");
                // Aplicar a todos los forms abiertos
                foreach (Form frm in Application.OpenForms)
                    Aplicar(frm);
                popup.Close();
            };

            // Click English
            btnEn.Click += (s, e) =>
            {
                Cargar("en");
                foreach (Form frm in Application.OpenForms)
                    Aplicar(frm);
                popup.Close();
            };

            popup.Controls.AddRange(new Control[] { lblTitulo, btnEs, btnEn });
            popup.ShowDialog(owner);
        }

        // ── Cambio directo (para uso programático) ────────────────────────
        public static void CambiarIdioma(string codigoIdioma)
        {
            Cargar(codigoIdioma);
            foreach (Form frm in Application.OpenForms)
                Aplicar(frm);
        }
    }
}
