using SISTEMA_INTEGRADOR_VOLUMEN_III.Controller;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class GestionUsuario : Form
    {
        private int _idSeleccionado = 0;

        public GestionUsuario()
        {
            InitializeComponent();
            Idioma.Aplicar(this);
        }

        // ── Métodos que usa CtlGestionUsuario ─────────────────────────────

        public int GetIdSeleccionado() => _idSeleccionado;
        public void SetIdSeleccionado(int id) => _idSeleccionado = id;

        /// <summary>
        /// Abre popup vacío para agregar.
        /// Devuelve datos o null si canceló.
        /// [0]Nombre [1]Documento [2]Telefono [3]Correo [4]Direccion [5]Username [6]Password [7]Rol
        /// </summary>
        public string[]? MostrarPopupAgregar() =>
            MostrarPopup("Agregar Usuario", "Registrar información del usuario",
                "", "", "", "", "", "", "Usuario", false);

        /// <summary>
        /// Abre popup con datos pre-rellenos para editar.
        /// Devuelve datos modificados o null si canceló.
        /// [0]Nombre [1]Documento [2]Telefono [3]Correo [4]Direccion [5]Username [6]Rol
        /// </summary>
        public string[]? MostrarPopupEditar(string nombre, string documento,
            string telefono, string correo, string direccion,
            string username, string rol) =>
            MostrarPopup("Editar Usuario", "Modificar información del usuario",
                nombre, documento, telefono, correo, direccion, username, rol, true);

        // ── Popup genérico ────────────────────────────────────────────────
        private string[]? MostrarPopup(string titulo, string subtitulo,
            string nombre, string documento, string telefono,
            string correo, string direccion, string username,
            string rolActual, bool esEdicion)
        {
            string[]? resultado = null;

            using Form popup = new Form
            {
                Text = titulo,
                Size = new Size(430, esEdicion ? 500 : 560),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            // Título y subtítulo
            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 30)
            };
            var lblSub = new Label
            {
                Text = subtitulo,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(20, 44),
                AutoSize = true
            };
            popup.Controls.Add(lblTitulo);
            popup.Controls.Add(lblSub);

            // Campos
            int y = 78;
            var txtNombre = AgregarCampo(popup, "Nombre", "Nombre del usuario", nombre, ref y);
            var txtDocumento = AgregarCampo(popup, "Identificación", "Número de identificación", documento, ref y);
            var txtTelefono = AgregarCampo(popup, "Teléfono", "Número telefónico", telefono, ref y);
            var txtCorreo = AgregarCampo(popup, "Correo", "Correo electrónico", correo, ref y);
            var txtDireccion = AgregarCampo(popup, "Dirección", "Dirección", direccion, ref y);
            var txtUsername = AgregarCampo(popup, "Usuario", "Nombre de usuario", username, ref y);

            // Contraseña solo al crear
            TextBox? txtPassword = null;
            if (!esEdicion)
                txtPassword = AgregarCampoPassword(popup, "Contraseña", "Contraseña", ref y);

            // ComboBox Rol
            var lblRol = new Label
            {
                Text = "Rol",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(20, y),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 30)
            };
            y += 22;
            var cmbRol = new ComboBox
            {
                Location = new Point(20, y),
                Size = new Size(380, 28),
                Font = new Font("Segoe UI", 10F),
                FlatStyle = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRol.Items.AddRange(new object[] { "Usuario", "Administrador" });
            cmbRol.SelectedItem = rolActual == "Administrador" ? "Administrador" : "Usuario";
            popup.Controls.Add(lblRol);
            popup.Controls.Add(cmbRol);
            y += 38;

            // Botones  ← idénticos a Clientes.cs
            y += 8;
            var btnCancelar = new Button
            {
                Text = "Cancelar",
                Size = new Size(100, 35),
                Location = new Point(195, y),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(80, 80, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) => popup.Close();

            var btnGuardar = new Button
            {
                Text = "Guardar",
                Size = new Size(100, 35),
                Location = new Point(305, y),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                    string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Nombre, Identificación y Usuario son obligatorios.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!esEdicion && string.IsNullOrWhiteSpace(txtPassword!.Text))
                {
                    MessageBox.Show("La contraseña es obligatoria.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (esEdicion)
                {
                    // [0]Nombre [1]Documento [2]Telefono [3]Correo [4]Direccion [5]Username [6]Rol
                    resultado = new[]
                    {
                        txtNombre.Text.Trim(),
                        txtDocumento.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtCorreo.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtUsername.Text.Trim(),
                        cmbRol.SelectedItem?.ToString() ?? "Usuario"
                    };
                }
                else
                {
                    // [0]Nombre [1]Documento [2]Telefono [3]Correo [4]Direccion [5]Username [6]Password [7]Rol
                    resultado = new[]
                    {
                        txtNombre.Text.Trim(),
                        txtDocumento.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtCorreo.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtUsername.Text.Trim(),
                        txtPassword!.Text.Trim(),
                        cmbRol.SelectedItem?.ToString() ?? "Usuario"
                    };
                }
                popup.Close();
            };

            popup.Controls.Add(btnCancelar);
            popup.Controls.Add(btnGuardar);
            popup.ClientSize = new Size(420, y + 50);
            popup.ShowDialog(this);

            return resultado;
        }

        // ── Helper: Label + TextBox apilados (igual que Clientes.cs) ─────
        private static TextBox AgregarCampo(Form popup, string etiqueta,
            string placeholder, string valor, ref int y)
        {
            var lbl = new Label
            {
                Text = etiqueta,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(20, y),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 30)
            };
            y += 22;
            var tb = new TextBox
            {
                Text = valor,
                PlaceholderText = placeholder,
                Location = new Point(20, y),
                Size = new Size(380, 28),
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle
            };
            popup.Controls.Add(lbl);
            popup.Controls.Add(tb);
            y += 38;
            return tb;
        }

        // ── Helper extra: TextBox con PasswordChar ────────────────────────
        private static TextBox AgregarCampoPassword(Form popup, string etiqueta,
            string placeholder, ref int y)
        {
            var tb = AgregarCampo(popup, etiqueta, placeholder, "", ref y);
            tb.PasswordChar = '●';
            return tb;
        }
    }
}   