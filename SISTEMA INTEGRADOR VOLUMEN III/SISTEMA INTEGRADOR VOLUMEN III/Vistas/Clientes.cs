using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

        // ── Métodos que usa CtlCliente ────────────────────────────────────

        public int GetIdSeleccionado() => _idSeleccionado;
        public void SetIdSeleccionado(int id) => _idSeleccionado = id;

        /// <summary>
        /// Abre popup vacío para agregar.
        /// Devuelve datos o null si canceló.
        /// [0]Nombre [1]Documento [2]Telefono [3]Correo [4]Direccion
        /// </summary>
        public string[]? MostrarPopupAgregar() =>
            MostrarPopup("Agregar Cliente", "Registrar información del cliente",
                "", "", "", "", "");

        /// <summary>
        /// Abre popup con datos pre-rellenos para editar.
        /// Devuelve datos modificados o null si canceló.
        /// </summary>
        public string[]? MostrarPopupEditar(string nombre, string documento,
            string telefono, string correo, string direccion) =>
            MostrarPopup("Editar Cliente", "Registrar información del cliente",
                nombre, documento, telefono, correo, direccion);

        // ── Popup genérico ────────────────────────────────────────────────
        private string[]? MostrarPopup(string titulo, string subtitulo,
            string nombre, string documento, string telefono,
            string correo, string direccion)
        {
            string[]? resultado = null;

            using Form popup = new Form
            {
                Text = titulo,
                Size = new Size(430, 420),
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
            var txtNombre = AgregarCampo(popup, "Nombre", "Nombre del cliente", nombre, ref y);
            var txtDocumento = AgregarCampo(popup, "Identificación", "Número de identificación", documento, ref y);
            var txtTelefono = AgregarCampo(popup, "Teléfono", "Número telefónico", telefono, ref y);
            var txtCorreo = AgregarCampo(popup, "Correo", "Correo electrónico", correo, ref y);
            var txtDireccion = AgregarCampo(popup, "Dirección", "Dirección", direccion, ref y);

            // Botones
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
                    string.IsNullOrWhiteSpace(txtDocumento.Text))
                {
                    MessageBox.Show("Nombre e Identificación son obligatorios.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                resultado = new[]
                {
                    txtNombre.Text.Trim(),
                    txtDocumento.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim()
                };
                popup.Close();
            };

            popup.Controls.Add(btnCancelar);
            popup.Controls.Add(btnGuardar);
            popup.ClientSize = new Size(420, y + 50);
            popup.ShowDialog(this);

            return resultado;
        }

        // ── Helper: Label + TextBox apilados ─────────────────────────────
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
    }
}