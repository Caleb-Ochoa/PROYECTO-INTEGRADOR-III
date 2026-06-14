using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class Clientes : Form
    {
        private int _idSeleccionado = 0;

        public Clientes()
        {
            InitializeComponent();
            Idioma.Aplicar(this);
        }

        public int GetIdSeleccionado() => _idSeleccionado;
        public void SetIdSeleccionado(int id) => _idSeleccionado = id;

        public string[]? MostrarPopupAgregar() =>
            MostrarPopup("Agregar Cliente", "Registrar información del cliente",
                "", "", "", "", "");

        public string[]? MostrarPopupEditar(string nombre, string documento,
            string telefono, string correo, string direccion) =>
            MostrarPopup("Editar Cliente", "Modificar información del cliente",
                nombre, documento, telefono, correo, direccion);

        private string[]? MostrarPopup(string titulo, string subtitulo,
            string nombre, string documento, string telefono,
            string correo, string direccion)
        {
            string[]? resultado = null;

            bool esAgregar = titulo == "Agregar Cliente";

            using Form popup = new Form
            {
                Text = esAgregar
                    ? Idioma.T("Agregar Cliente", "Add Client")
                    : Idioma.T("Editar Cliente", "Edit Client"),
                Name = "PopupCliente",
                Size = new Size(430, 420),
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
                    ? "Register client information"
                    : "Modify client information"),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(20, 44),
                AutoSize = true
            };
            popup.Controls.Add(lblTitulo);
            popup.Controls.Add(lblSub);

            int y = 78;
            var txtNombre = AgregarCampo(popup, "lblNombre", Idioma.T("Nombre", "Name"), Idioma.T("Nombre del cliente", "Client name"), nombre, ref y);
            var txtDocumento = AgregarCampo(popup, "lblDocumento", Idioma.T("Identificación", "ID"), Idioma.T("Número de identificación", "ID number"), documento, ref y);
            var txtTelefono = AgregarCampo(popup, "lblTelefono", Idioma.T("Teléfono", "Phone"), Idioma.T("Número telefónico", "Phone number"), telefono, ref y);
            var txtCorreo = AgregarCampo(popup, "lblCorreo", Idioma.T("Correo", "Email"), Idioma.T("Correo electrónico", "Email address"), correo, ref y);
            var txtDireccion = AgregarCampo(popup, "lblDireccion", Idioma.T("Dirección", "Address"), Idioma.T("Dirección", "Address"), direccion, ref y);

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
                    string.IsNullOrWhiteSpace(txtDocumento.Text))
                {
                    MessageBox.Show(
                        Idioma.T("Nombre e Identificación son obligatorios.",
                                 "Name and ID are required."),
                        Idioma.T("Advertencia", "Warning"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                resultado = new[]
                {
                    txtNombre.Text.Trim(), txtDocumento.Text.Trim(),
                    txtTelefono.Text.Trim(), txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim()
                };
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
    }
}