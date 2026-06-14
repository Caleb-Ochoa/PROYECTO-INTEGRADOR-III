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

            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "traducciones.txt");

            if (!File.Exists(ruta)) return;

            foreach (string linea in File.ReadAllLines(ruta, System.Text.Encoding.UTF8))
            {
                string l = linea.Trim();
                if (string.IsNullOrEmpty(l) || l.StartsWith("#")) continue;

                string[] p = l.Split('|');

                if (p.Length == 4)
                {
                    // Control normal: nombreControl|NombreFormulario|ES|EN
                    string clave = $"{p[1].Trim()}|{p[0].Trim()}";
                    _textos[clave] = codigoIdioma == "en" ? p[3].Trim() : p[2].Trim();
                }
                else if (p.Length == 5)
                {
                    // Columna de grid: nombreGrid|NombreFormulario|nombreColumna|ES|EN
                    string clave = $"{p[1].Trim()}|{p[0].Trim()}|{p[2].Trim()}";
                    _textos[clave] = codigoIdioma == "en" ? p[4].Trim() : p[3].Trim();
                }
            }
        }

        public static void AplicarGrid(DataGridView dgv, string nombreForm)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                string clave = $"{nombreForm}|{dgv.Name}|{col.Name}";
                if (_textos.TryGetValue(clave, out string? headerTexto))
                    col.HeaderText = headerTexto;
            }
        }
        public static string T(string español, string english)
    => IdiomaActual == "en" ? english : español;

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
                        // DataGridView: NO tocar columnas, solo el control en sí no tiene Text
                }
            }

            // Si es DataGridView, traducir columnas por nombre
            if (ctrl is DataGridView dgv)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    string clavCol = $"{nombreForm}|{dgv.Name}|{col.Name}";
                    if (_textos.TryGetValue(clavCol, out string? headerTexto))
                        col.HeaderText = headerTexto;
                }
                return; // No seguir recursión dentro del grid
            }

            foreach (Control hijo in ctrl.Controls)
                AplicarRecursivo(hijo, nombreForm);
        }

        // ── Selector de idioma inline — sin formulario extra ──────────────
        /// <summary>
        /// Muestra un pequeño popup bilingüe para elegir idioma.
        /// Llamar desde btnIdioma_Click en Login, RegistroAdmin y MenuPrincipal.
        /// </summary>
        public static void MostrarSelector(Form owner)
        {
            using Form popup = new Form
            {
                Text = "Idioma / Language",
                Size = new Size(280, 130),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            var lbl = new Label
            {
                Text = "Seleccione / Select language:",
                AutoSize = false,
                Width = 260,
                Location = new Point(10, 10),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F)
            };

            var btnEs = new Button
            {
                Text = "🇨🇴  Español",
                Size = new Size(115, 40),
                Location = new Point(10, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = IdiomaActual == "es" ? Color.SteelBlue : Color.WhiteSmoke,
                ForeColor = IdiomaActual == "es" ? Color.White : Color.Black,
                Font = new Font("Segoe UI", 9.5F)
            };
            btnEs.FlatAppearance.BorderSize = 0;

            var btnEn = new Button
            {
                Text = "🇺🇸  English",
                Size = new Size(115, 40),
                Location = new Point(145, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = IdiomaActual == "en" ? Color.SteelBlue : Color.WhiteSmoke,
                ForeColor = IdiomaActual == "en" ? Color.White : Color.Black,
                Font = new Font("Segoe UI", 9.5F)
            };
            btnEn.FlatAppearance.BorderSize = 0;

            btnEs.Click += (s, e) =>
            {
                Cargar("es");
                foreach (Form frm in Application.OpenForms)
                    Aplicar(frm);
                popup.Close();
            };

            btnEn.Click += (s, e) =>
            {
                Cargar("en");
                foreach (Form frm in Application.OpenForms)
                    Aplicar(frm);
                popup.Close();
            };

            popup.Controls.AddRange(new Control[] { lbl, btnEs, btnEn });
            popup.ShowDialog(owner);
        }
    }
}
