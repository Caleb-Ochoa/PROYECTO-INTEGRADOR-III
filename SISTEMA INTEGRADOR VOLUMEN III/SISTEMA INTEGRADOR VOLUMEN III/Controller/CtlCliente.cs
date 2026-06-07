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

            // ── Cargar grid al abrir ─────────────────────────────────────
            CargarGrid();

            // ── Guardar ──────────────────────────────────────────────────
            Vista.btnGuardarCliente.Click += (sender, e) =>
            {
                Add();
                Save();
            };

            // ── Limpiar formulario ───────────────────────────────────────
            Vista.btnLimpiarCliente.Click += (sender, e) =>
            {
                Limpiar();
            };

            // ── Buscar ───────────────────────────────────────────────────
            Vista.btnBuscarCliente.Click += (sender, e) =>
            {
                Buscar();
            };

            // ── Limpiar búsqueda ─────────────────────────────────────────
            Vista.btnLimpiarFiltro.Click += (sender, e) =>
            {
                Vista.txtBuscarCliente.Clear();
                CargarGrid();
            };

            // ── Click en fila del grid → cargar en formulario ────────────
            Vista.dataGridView1.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                    CargarEnFormulario(e.RowIndex);
            };
        }

        // ── CRUD ─────────────────────────────────────────────────────────

        private void Add()
        {
            string[] line = Vista.GetInput();
            // line[0]=Nombre, [1]=Documento, [2]=Correo, [3]=Telefono, [4]=Direccion

            //if (string.IsNullOrWhiteSpace(line[0]) || string.IsNullOrWhiteSpace(line[1]))
            //{
            //    MessageBox.Show(
            //        Idioma.Get("msg_campos_vacios"),
            //        Idioma.Get("msg_error"),
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            try
            {
                // Si hay un id seleccionado → actualizar, si no → crear nuevo
                int idSeleccionado = Vista.GetIdSeleccionado();

                if (idSeleccionado > 0)
                {
                    // Actualizar cliente existente
                    int idx = clientes.FindIndex(c => c.Id == idSeleccionado);
                    if (idx >= 0)
                    {
                        clientes[idx].Nombre = line[0];
                        clientes[idx].Documento = line[1];
                        clientes[idx].CorreoElectronico = line[2];
                        clientes[idx].Telefono = line[3];
                        clientes[idx].Direccion = line[4];
                    }
                }
                else
                {
                    // Verificar documento duplicado
                    if (clientes.Any(c => c.Documento == line[1].Trim()))
                        throw new InvalidOperationException(
                            "Ya existe un cliente con ese documento.");

                    Cliente cliente = new Cliente
                    {
                        Id = dataManager.GetNextId(),
                        Nombre = line[0],
                        Documento = line[1],
                        CorreoElectronico = line[2],
                        Telefono = line[3],
                        Direccion = line[4],
                        FechaRegistro = DateTime.Now
                    };

                    clientes.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message,
                    //Idioma.Get("msg_error"),
                    //MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save()
        {
            dataManager.Save(clientes);
            CargarGrid();
            Limpiar();
        }

        public List<Cliente> Listar()
        {
            clientes = dataManager.GetAll();
            return clientes;
        }

        // ── Helpers de UI ─────────────────────────────────────────────────

        private void CargarGrid()
        {
            clientes = dataManager.GetAll();
            Vista.dataGridView1.DataSource = null;
            Vista.dataGridView1.DataSource = clientes.Select(c => new
            {
                c.Id,
                c.Nombre,
                c.Documento,
                Correo = c.CorreoElectronico,
                c.Telefono,
                c.Direccion,
                Registro = c.FechaRegistro.ToString("dd/MM/yyyy")
            }).ToList();
        }

        private void CargarEnFormulario(int rowIndex)
        {
            // Obtener el Id de la fila seleccionada
            if (Vista.dataGridView1.Rows[rowIndex].Cells["Id"].Value == null) return;

            int id = (int)Vista.dataGridView1.Rows[rowIndex].Cells["Id"].Value;
            Cliente? c = clientes.FirstOrDefault(x => x.Id == id);
            if (c == null) return;

            Vista.SetIdSeleccionado(id);
            Vista.txtNombreClientec.Text = c.Nombre;
            Vista.txtDocumentoCliente.Text = c.Documento;
            Vista.txtCCliente.Text = c.CorreoElectronico;
            Vista.txtTelefonoCliente.Text = c.Telefono;
            Vista.txtDireccionCliente.Text = c.Direccion;
        }

        private void Buscar()
        {
            string termino = Vista.txtBuscarCliente.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termino))
            {
                CargarGrid();
                return;
            }

            var resultado = clientes
                .Where(c =>
                    c.Nombre.ToLower().Contains(termino) ||
                    c.Documento.ToLower().Contains(termino))
                .Select(c => new
                {
                    c.Id,
                    c.Nombre,
                    c.Documento,
                    Correo = c.CorreoElectronico,
                    c.Telefono,
                    c.Direccion,
                    Registro = c.FechaRegistro.ToString("dd/MM/yyyy")
                }).ToList();

            Vista.dataGridView1.DataSource = null;
            Vista.dataGridView1.DataSource = resultado;
        }

        private void Limpiar()
        {
            Vista.txtNombreClientec.Clear();
            Vista.txtDocumentoCliente.Clear();
            Vista.txtCCliente.Clear();
            Vista.txtTelefonoCliente.Clear();
            Vista.txtDireccionCliente.Clear();
            Vista.txtBuscarCliente.Clear();
            Vista.SetIdSeleccionado(0);
            Vista.dataGridView1.ClearSelection();
        }
    }
}
