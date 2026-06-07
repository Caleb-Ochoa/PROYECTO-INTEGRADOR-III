using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Controller
{
    internal class CtlCliente
    {
        public Clientes Vista { get; set; }

        private DataManager<Cliente> dataManager;
        private List<Cliente> clientes;

        public CtlCliente(DataManager<Cliente> dataManager, Clientes vista)
        {
            this.dataManager = dataManager;
            this.Vista = vista;

            clientes = dataManager.GetAll();

            // Cargar grid al abrir
            CargarGrid();

            // ── Botón Agregar ─────────────────────────────────────────────
            Vista.btnAgregarCliente.Click += (sender, e) =>
            {
                string[]? datos = Vista.MostrarPopupAgregar();
                if (datos == null) return;
                Agregar(datos);
            };

            // ── Botón Buscar ──────────────────────────────────────────────
            Vista.btnBuscarCliente.Click += (sender, e) =>
            {
                Buscar();
            };

            // Buscar también en tiempo real al escribir
            Vista.txtBuscarCliente.TextChanged += (sender, e) =>
            {
                Buscar();
            };

            // ── Botón Limpiar filtro ──────────────────────────────────────
            Vista.btnLimpiarFiltro.Click += (sender, e) =>
            {
                Vista.txtBuscarCliente.Clear();
                CargarGrid();
            };
        }

        // ── CRUD ──────────────────────────────────────────────────────────

        private void Agregar(string[] datos)
        {
            // [0]Nombre [1]Documento [2]Telefono [3]Correo [4]Direccion
            try
            {
                if (clientes.Any(c => c.Documento == datos[1].Trim()))
                    throw new InvalidOperationException(
                        "Ya existe un cliente con ese número de identificación.");

                clientes.Add(new Cliente
                {
                    Id = dataManager.GetNextId(),
                    Nombre = datos[0],
                    Documento = datos[1],
                    Telefono = datos[2],
                    CorreoElectronico = datos[3],
                    Direccion = datos[4],
                    FechaRegistro = DateTime.Now
                });

                Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Editar(int id)
        {
            Cliente? c = clientes.FirstOrDefault(x => x.Id == id);
            if (c == null) return;

            string[]? datos = Vista.MostrarPopupEditar(
                c.Nombre, c.Documento, c.Telefono,
                c.CorreoElectronico, c.Direccion);

            if (datos == null) return;

            try
            {
                int idx = clientes.FindIndex(x => x.Id == id);
                clientes[idx].Nombre = datos[0];
                clientes[idx].Documento = datos[1];
                clientes[idx].Telefono = datos[2];
                clientes[idx].CorreoElectronico = datos[3];
                clientes[idx].Direccion = datos[4];
                Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save()
        {
            dataManager.Save(clientes);
            CargarGrid();
        }

        public List<Cliente> Listar()
        {
            clientes = dataManager.GetAll();
            return clientes;
        }

        // ── Grid ──────────────────────────────────────────────────────────

        private void CargarGrid()
        {
            clientes = dataManager.GetAll();

            Vista.dataGridView1.DataSource = null;
            Vista.dataGridView1.DataSource = clientes.Select(c => new
            {
                c.Id,
                c.Nombre,
                Identificacion = c.Documento,
                c.Telefono,
                Correo = c.CorreoElectronico,
                Registro = c.FechaRegistro.ToString("dd/MM/yyyy")
            }).ToList();

            // Ocultar columna Id
            if (Vista.dataGridView1.Columns.Contains("Id"))
                Vista.dataGridView1.Columns["Id"].Visible = false;

            EstilizarGrid();
            AgregarColumnaEditar();
        }

        private void EstilizarGrid()
        {
            Vista.dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            Vista.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(240, 240, 240);
            Vista.dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Vista.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(60, 60, 60);
            Vista.dataGridView1.EnableHeadersVisualStyles = false;
            Vista.dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F);
            Vista.dataGridView1.RowTemplate.Height = 32;
            Vista.dataGridView1.BackgroundColor = Color.White;
            Vista.dataGridView1.GridColor = Color.FromArgb(230, 230, 230);
        }

        private void AgregarColumnaEditar()
        {
            // Evitar duplicados al recargar
            if (Vista.dataGridView1.Columns.Contains("Acciones"))
                Vista.dataGridView1.Columns.Remove("Acciones");

            var colBtn = new DataGridViewButtonColumn
            {
                Name = "Acciones",
                HeaderText = "Acciones",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 90,
                DefaultCellStyle =
                {
                    BackColor = Color.FromArgb(16, 185, 129),
                    ForeColor = Color.White,
                    Font      = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding   = new Padding(0, 2, 0, 2)
                }
            };

            Vista.dataGridView1.Columns.Add(colBtn);

            // Reconectar el evento para evitar duplicados
            Vista.dataGridView1.CellClick -= GridCellClick;
            Vista.dataGridView1.CellClick += GridCellClick;
        }

        private void GridCellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (Vista.dataGridView1.Columns[e.ColumnIndex].Name != "Acciones") return;

            var celda = Vista.dataGridView1.Rows[e.RowIndex].Cells["Id"];
            if (celda?.Value == null) return;

            int id = (int)celda.Value;
            Editar(id);
        }

        private void Buscar()
        {
            string termino = Vista.txtBuscarCliente.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termino)) { CargarGrid(); return; }

            Vista.dataGridView1.DataSource = null;
            Vista.dataGridView1.DataSource = clientes
                .Where(c => c.Nombre.ToLower().Contains(termino) ||
                            c.Documento.ToLower().Contains(termino))
                .Select(c => new
                {
                    c.Id,
                    c.Nombre,
                    Identificacion = c.Documento,
                    c.Telefono,
                    Correo = c.CorreoElectronico,
                    Registro = c.FechaRegistro.ToString("dd/MM/yyyy")
                }).ToList();

            if (Vista.dataGridView1.Columns.Contains("Id"))
                Vista.dataGridView1.Columns["Id"].Visible = false;

            EstilizarGrid();
            AgregarColumnaEditar();
        }
    }
}
