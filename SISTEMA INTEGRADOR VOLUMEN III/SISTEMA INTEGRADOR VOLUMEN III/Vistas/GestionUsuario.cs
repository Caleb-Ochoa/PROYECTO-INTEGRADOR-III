using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class GestionUsuario : Form
    {
        private int _idSeleccionado = 0;

        public GestionUsuario()
        {
            InitializeComponent();
        }

        public int GetIdSeleccionado() => _idSeleccionado;
        public void SetIdSeleccionado(int id) => _idSeleccionado = id;

        public string[]? MostrarPopupAgregar() =>
            MostrarPopup("Agregar Usuario", "Registrar información del usuario",
                "", "", "", "", "", "", "Usuario", false);

        public string[]? MostrarPopupEditar(string nombre, string documento,
            string telefono, string correo, string direccion,
            string username, string rol) =>
            MostrarPopup("Editar Usuario", "Modificar información del usuario",
                nombre, documento, telefono, correo, direccion, username, rol, true);

        private string[]? MostrarPopup(string titulo, string subtitulo,
            string nombre, string documento, string telefono,
            string correo, string direccion, string username,
            string rolActual, bool esEdicion)
        {
            string[]? resultado = null;
            bool esAgregar = !esEdicion;

            using Form popup = new Form
            {
                Text = esAgregar
("Agregar Usuario", "Editar Usuario"),
                Name = "PopupUsuario",
                Size = new Size(430, esEdicion ? 500 : 560),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            var lblTitulo = new Label
            {
                Name = "lblTitulo",
                Text = popup.Text,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 30)
            };
            var lblSub = new Label
            {
                Name = "lblSub",
                Text = Idioma.T(subtitulo, esAgregar
                    ? "Register user information" : "Modify user information"),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(20, 44),
                AutoSize = true
            };
            popup.Controls.Add(lblTitulo);
            popup.Controls.Add(lblSub);

            int y = 78;
            var txtNombre = AgregarCampo(popup, "lblNombre", Idioma.T("Nombre", "Name"), Idioma.T("Nombre del usuario", "User name"), nombre, ref y);
            var txtDocumento = AgregarCampo(popup, "lblDocumento", Idioma.T("Identificación", "ID"), Idioma.T("Número de identificación", "ID number"), documento, ref y);
            var txtTelefono = AgregarCampo(popup, "lblTelefono", Idioma.T("Teléfono", "Phone"), Idioma.T("Número telefónico", "Phone number"), telefono, ref y);
            var txtCorreo = AgregarCampo(popup, "lblCorreo", Idioma.T("Correo", "Email"), Idioma.T("Correo electrónico", "Email address"), correo, ref y);
            var txtDireccion = AgregarCampo(popup, "lblDireccion", Idioma.T("Dirección", "Address"), Idioma.T("Dirección", "Address"), direccion, ref y);
            var txtUsername = AgregarCampo(popup, "lblUsername", Idioma.T("Usuario", "Username"), Idioma.T("Nombre de usuario", "Username"), username, ref y);

            TextBox? txtPassword = null;
            if (!esEdicion)
                txtPassword = AgregarCampoPassword(popup, "lblPassword",
                    Idioma.T("Contraseña", "Password"),
                    Idioma.T("Contraseña", "Password"), ref y);

            var lblRol = new Label
            {
                Name = "lblRol",
                Text = Idioma.T("Rol", "Role"),
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
            cmbRol.Items.AddRange(new object[]
            {
                Idioma.T("Usuario", "User"),
                Idioma.T("Administrador", "Administrator")
            });
            cmbRol.SelectedIndex = rolActual == "Administrador" ? 1 : 0;
            popup.Controls.Add(lblRol);
            popup.Controls.Add(cmbRol);
            y += 38;

            y += 8;
            var btnCancelar = new Button
            {
                Name = "btnCancelar",
                Text = Idioma.T("Cancelar", "Cancel"),
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
                Name = "btnGuardar",
                Text = Idioma.T("Guardar", "Save"),
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
                    MessageBox.Show(
                        Idioma.T("Nombre, Identificación y Usuario son obligatorios.",
                                 "Name, ID and Username are required."),
                        Idioma.T("Advertencia", "Warning"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!esEdicion && string.IsNullOrWhiteSpace(txtPassword!.Text))
                {
                    MessageBox.Show(
                        Idioma.T("La contraseña es obligatoria.", "Password is required."),
                        Idioma.T("Advertencia", "Warning"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!esEdicion)
                {
                    try { Services.AuthService.ValidarPassword(txtPassword!.Text); }
                    catch (Exception exVal)
                    {
                        MessageBox.Show(exVal.Message,
                            Idioma.T("Contraseña inválida", "Invalid password"),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword!.Focus();
                        return;
                    }
                }

                // Mapear rol de vuelta a valor en español para el modelo
                string rolElegido = cmbRol.SelectedIndex == 1 ? "Administrador" : "Usuario";

                resultado = esEdicion
                    ? new[] { txtNombre.Text.Trim(), txtDocumento.Text.Trim(),
                              txtTelefono.Text.Trim(), txtCorreo.Text.Trim(),
                              txtDireccion.Text.Trim(), txtUsername.Text.Trim(),
                              rolElegido }
                    : new[] { txtNombre.Text.Trim(), txtDocumento.Text.Trim(),
                              txtTelefono.Text.Trim(), txtCorreo.Text.Trim(),
                              txtDireccion.Text.Trim(), txtUsername.Text.Trim(),
                              txtPassword!.Text, rolElegido };
                popup.Close();
            };

            popup.Controls.Add(btnCancelar);
            popup.Controls.Add(btnGuardar);
            popup.ClientSize = new Size(420, y + 50);
            popup.Shown += (s, e) => txtNombre.Focus();
            popup.ShowDialog(this);
            return resultado;
        }

        private static TextBox AgregarCampo(Form popup, string lblName,
            string etiqueta, string placeholder, string valor, ref int y)
        {
            var lbl = new Label
            {
                Name = lblName,
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

        private static TextBox AgregarCampoPassword(Form popup, string lblName,
            string etiqueta, string placeholder, ref int y)
        {
            var tb = AgregarCampo(popup, lblName, etiqueta, placeholder, "", ref y);
            tb.PasswordChar = '*';
            return tb;
        }

        public string? MostrarPopupRestablecerPassword(string nombreUsuario)
        {
            string? nuevaPassword = null;

            using Form popup = new Form
            {
                Text = Idioma.T("Restablecer Contraseña", "Reset Password"),
                Name = "PopupResetPass",
                Size = new Size(420, 280),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            var lblTitulo = new Label
            {
                Name = "lblTitulo",
                Text = Idioma.T("Restablecer Contraseña", "Reset Password"),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 30)
            };
            var lblSub = new Label
            {
                Name = "lblSub",
                Text = Idioma.T($"Nueva contraseña para: {nombreUsuario}",
                                $"New password for: {nombreUsuario}"),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(20, 44),
                AutoSize = true
            };
            popup.Controls.Add(lblTitulo);
            popup.Controls.Add(lblSub);

            int y = 80;
            var txtNueva = AgregarCampoPassword(popup, "lblNueva",
                Idioma.T("Nueva contraseña", "New password"),
                Idioma.T("Mínimo 8 caracteres", "Minimum 8 characters"), ref y);
            var txtConfirmar = AgregarCampoPassword(popup, "lblConfirmar",
                Idioma.T("Confirmar contraseña", "Confirm password"),
                Idioma.T("Repite la contraseña", "Repeat password"), ref y);

            var btnCancelar = new Button
            {
                Name = "btnCancelar",
                Text = Idioma.T("Cancelar", "Cancel"),
                Size = new Size(100, 35),
                Location = new Point(190, y + 8),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(80, 80, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F)
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) => popup.Close();

            var btnRestablecer = new Button
            {
                Name = "btnRestablecer",
                Text = Idioma.T("Restablecer", "Reset"),
                Size = new Size(110, 35),
                Location = new Point(300, y + 8),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(220, 38, 38),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };
            btnRestablecer.FlatAppearance.BorderSize = 0;
            btnRestablecer.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtNueva.Text) ||
                    string.IsNullOrWhiteSpace(txtConfirmar.Text))
                {
                    MessageBox.Show(
                        Idioma.T("Todos los campos son obligatorios.", "All fields are required."),
                        Idioma.T("Advertencia", "Warning"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtNueva.Text != txtConfirmar.Text)
                {
                    MessageBox.Show(
                        Idioma.T("Las contraseñas no coinciden.", "Passwords do not match."),
                        Idioma.T("Advertencia", "Warning"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try { Services.AuthService.ValidarPassword(txtNueva.Text); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        Idioma.T("Contraseña inválida", "Invalid password"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNueva.Focus();
                    return;
                }
                nuevaPassword = txtNueva.Text;
                popup.Close();
            };

            popup.Controls.Add(btnCancelar);
            popup.Controls.Add(btnRestablecer);
            popup.ClientSize = new Size(420, y + 65);
            popup.Shown += (s, e) => txtNueva.Focus();
            popup.ShowDialog(this);
            return nuevaPassword;
        }
    }
}