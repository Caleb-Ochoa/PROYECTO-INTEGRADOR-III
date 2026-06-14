using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Controller
{
    internal class CtlMaterial
    {
        public Materiales Vista { get; set; }

        private readonly DataManager<Material> _dm;
        private List<Material> _materiales;

        public CtlMaterial(DataManager<Material> dm, Materiales vista)
        {
            _dm = dm;
            Vista = vista;

            _materiales = _dm.GetAll();

            // Carga inicial del grid
            CargarGrid();

            // ── Guardar / Actualizar ──────────────────────────────────────
            Vista.btnGuardarMaterial.Click += (s, e) =>
            {
                if (Vista.EstaEditando())
                    Actualizar();
                else
                    Agregar();
            };

            // ── Limpiar formulario ────────────────────────────────────────
            Vista.btnLimpiarMaterial.Click += (s, e) =>
            {
                Vista.LimpiarFormulario();
            };

            // ── Buscar en tiempo real ─────────────────────────────────────
            Vista.txtBuscarMateriales.TextChanged += (s, e) => Buscar();

            // ── Botón Buscar ──────────────────────────────────────────────
            Vista.btnBuscarMateriales.Click += (s, e) => Buscar();

            // ── Limpiar filtro ────────────────────────────────────────────
            Vista.btnLimpiarMateriales.Click += (s, e) =>
            {
                Vista.txtBuscarMateriales.Clear();
                CargarGrid();
            };

            // ── Click en fila del grid para editar ────────────────────────
            Vista.GetGrid().CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                if (Vista.GetGrid().Columns[e.ColumnIndex].Name != "Acciones") return;

                var celda = Vista.GetGrid().Rows[e.RowIndex].Cells["Id"];
                if (celda?.Value == null) return;

                int id = (int)celda.Value;
                CargarParaEditar(id);
            };
        }

        // ── CRUD ──────────────────────────────────────────────────────────

        private void Agregar()
        {
            string[] datos = Vista.GetInput();

            if (!ValidarInput(datos, out string error))
            {
                Vista.MostrarAdvertencia(error);
                return;
            }

            try
            {
                // Verificar nombre duplicado
                if (_materiales.Any(m =>
                        string.Equals(m.Nombre, datos[0],
                            StringComparison.OrdinalIgnoreCase)))
                {
                    Vista.MostrarAdvertencia("Ya existe un material con ese nombre.");
                    return;
                }

                _materiales.Add(new Material
                {
                    Id = _dm.GetNextId(),
                    Nombre = datos[0],
                    CostoMetroCubico = decimal.Parse(datos[1],
                        System.Globalization.CultureInfo.InvariantCulture)
                });

                Save();
                Vista.LimpiarFormulario();
                Vista.MostrarMensaje("Material agregado correctamente.");
            }
            catch (Exception ex)
            {
                Vista.MostrarMensaje(ex.Message, esError: true);
            }
        }

        private void Actualizar()
        {
            string[] datos = Vista.GetInput();

            if (!ValidarInput(datos, out string error))
            {
                Vista.MostrarAdvertencia(error);
                return;
            }

            try
            {
                int id = Vista.GetIdEditando();
                int idx = _materiales.FindIndex(m => m.Id == id);
                if (idx < 0) throw new InvalidOperationException("Material no encontrado.");

                // Verificar nombre duplicado en otro registro
                if (_materiales.Any(m =>
                        m.Id != id &&
                        string.Equals(m.Nombre, datos[0],
                            StringComparison.OrdinalIgnoreCase)))
                {
                    Vista.MostrarAdvertencia("Ya existe otro material con ese nombre.");
                    return;
                }

                _materiales[idx].Nombre = datos[0];
                _materiales[idx].CostoMetroCubico = decimal.Parse(datos[1],
                    System.Globalization.CultureInfo.InvariantCulture);

                Save();
                Vista.LimpiarFormulario();
                Vista.MostrarMensaje("Material actualizado correctamente.");
            }
            catch (Exception ex)
            {
                Vista.MostrarMensaje(ex.Message, esError: true);
            }
        }

        private void CargarParaEditar(int id)
        {
            Material? m = _materiales.FirstOrDefault(x => x.Id == id);
            if (m == null) return;

            Vista.CargarEnFormulario(
                m.Id,
                m.Nombre,
                m.CostoMetroCubico.ToString(System.Globalization.CultureInfo.InvariantCulture)
            );
        }

        private void Save()
        {
            _dm.Save(_materiales);
            _materiales = _dm.GetAll();
            CargarGrid();
        }

        // ── Grid ──────────────────────────────────────────────────────────

        private void CargarGrid()
        {
            _materiales = _dm.GetAll();

            Vista.CargarGrid(
                _materiales.Select(m => new
                {
                    m.Id,
                    m.Nombre,
                    CostoM3 = m.CostoMetroCubico.ToString("C2")
                }).ToList()
            );

            EstilizarGrid();
            AgregarColumnaEditar();
        }

        private void EstilizarGrid()
        {
            var dgv = Vista.GetGrid();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersDefaultCellStyle.BackColor =System.Drawing.Color.FromArgb(240, 240, 240);
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.Font =new System.Drawing.Font("Segoe UI", 9.5F);
            dgv.RowTemplate.Height = 32;
            dgv.BackgroundColor = System.Drawing.Color.White;

            // Ocultar columna Id — no necesita verla el usuario
            if (dgv.Columns.Contains("Id"))
                dgv.Columns["Id"].Visible = false;
        }

        private void AgregarColumnaEditar()
        {
            var dgv = Vista.GetGrid();

            if (dgv.Columns.Contains("Acciones"))
                dgv.Columns.Remove("Acciones");

            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Acciones",
                HeaderText = "Acciones",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 90,
                DefaultCellStyle =
                {
                    BackColor = System.Drawing.Color.FromArgb(16, 185, 129),
                    ForeColor = System.Drawing.Color.White,
                    Font      = new System.Drawing.Font("Segoe UI", 9F,System.Drawing.FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
        }

        private void Buscar()
        {
            string termino = Vista.GetTextoBusqueda().ToLower();
            if (string.IsNullOrEmpty(termino)) { CargarGrid(); return; }

            var dgv = Vista.GetGrid();
            dgv.DataSource = null;
            dgv.DataSource = _materiales.Where(m => m.Nombre.ToLower().Contains(termino)).Select(m => new
                {
                    m.Id,
                    m.Nombre,
                    CostoM3 = m.CostoMetroCubico.ToString("C2")
                }).ToList();

            EstilizarGrid();
            AgregarColumnaEditar();
        }

        // ── Validación ────────────────────────────────────────────────────

        private static bool ValidarInput(string[] datos, out string error)
        {
            if (string.IsNullOrWhiteSpace(datos[0]))
            {
                error = "El nombre del material es obligatorio.";
                return false;
            }

            if (!decimal.TryParse(datos[1],
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal costo) || costo <= 0)
            {
                error = "El costo debe ser un número mayor a 0. Usa punto como separador decimal (ej: 150.50).";
                return false;
            }

            error = string.Empty;
            return true;
        }

        // ── Método público para que otros controladores consulten ─────────
        public List<Material> Listar()
        {
            _materiales = _dm.GetAll();
            return _materiales;
        }
    }
}
