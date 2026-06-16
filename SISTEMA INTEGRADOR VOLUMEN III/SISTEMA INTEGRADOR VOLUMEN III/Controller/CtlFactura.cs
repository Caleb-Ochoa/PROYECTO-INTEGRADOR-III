using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Controller
{
    internal class CtlFactura
    {
        public Facturas Vista { get; set; }

        private readonly DataManager<Factura> _dmFac;
        private readonly DataManager<Cotizacion> _dmCot;
        private readonly DataManager<Cliente> _dmCli;
        private readonly DataManager<Terreno> _dmTer;
        private readonly DataManager<Material> _dmMat;

        private List<Factura> _facturas;
        private List<Cotizacion> _cotizaciones;
        private List<Cliente> _clientes;
        private List<Terreno> _terrenos;
        private List<Material> _materiales;

        public CtlFactura(DataManager<Factura> dmFac,DataManager<Cotizacion> dmCot,
            DataManager<Cliente> dmCli,DataManager<Terreno> dmTer,DataManager<Material> dmMat,
            Facturas vista)
        {
            _dmFac = dmFac;
            _dmCot = dmCot;
            _dmCli = dmCli;
            _dmTer = dmTer;
            _dmMat = dmMat;
            Vista = vista;

            _facturas = _dmFac.GetAll();
            _cotizaciones = _dmCot.GetAll();
            _clientes = _dmCli.GetAll();
            _terrenos = _dmTer.GetAll();
            _materiales = _dmMat.GetAll();

            CargarGrid();

            Vista.btnBuscarFacturas.Click += (s, e) => Buscar();
            Vista.txtBuscarFacturas.TextChanged += (s, e) => Buscar();

            Vista.btnLimpiarFacturas.Click += (s, e) =>
            {
                Vista.txtBuscarFacturas.Clear();
                CargarGrid();
            };

            Vista.dvgFacturas.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                string col = Vista.dvgFacturas.Columns[e.ColumnIndex].Name;
                var celda = Vista.dvgFacturas.Rows[e.RowIndex].Cells["Id"];
                if (celda?.Value == null) return;
                int id = (int)celda.Value;

                if (col == "ColDescargar") DescargarFactura(id);
                else if (col == "ColAnular") AnularFactura(id);
            };

            Vista.dvgFacturas.CellPainting += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                if (Vista.dvgFacturas.Columns[e.ColumnIndex].Name != "ColAnular") return;

                string estado = Vista.dvgFacturas.Rows[e.RowIndex].Cells["Estado"].Value?.ToString() ?? "";

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Color btnColor = estado == "Anulada" ? Color.FromArgb(160, 160, 160) : Color.FromArgb(220, 38, 38);
                string btnText = estado == "Anulada" ? "Anulada" : "Anular";

                using var brush = new SolidBrush(btnColor);
                var rect = new Rectangle(e.CellBounds.X + 2, e.CellBounds.Y + 2,
                    e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                e.Graphics.FillRectangle(brush, rect);

                using var txtBrush = new SolidBrush(Color.White);
                var fmt = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(btnText,new Font("Segoe UI", 9F, FontStyle.Bold),txtBrush, rect, fmt);
                e.Handled = true;
            };
        }

        private void DescargarFactura(int id)
        {
            Factura? fac = _facturas.FirstOrDefault(f => f.Id == id);
            if (fac == null) return;

            Cotizacion? cot = _cotizaciones.FirstOrDefault(c => c.Id == fac.CotizacionId);
            Cliente? cli = _clientes.FirstOrDefault(c => c.Id == fac.ClienteId);
            Terreno? ter = cot != null? _terrenos.FirstOrDefault(t => t.Id == cot.TerrenoId) : null;
            Material? mat = cot != null ? _materiales.FirstOrDefault(m => m.Id == cot.MaterialId) : null;

            if (cot == null || cli == null || ter == null || mat == null)
            {
                Vista.MostrarMensaje("No se encontraron todos los datos de la factura.",esError: true);
                return;
            }

            Vista.DescargarFacturaPDF(fac, cli, cot, ter, mat);
        }

        private void AnularFactura(int id)
        {
            Factura? fac = _facturas.FirstOrDefault(f => f.Id == id);
            if (fac == null) return;
            if (fac.Estado == EstadoFactura.Anulada) return;

            if (MessageBox.Show("¿Está seguro de anular esta factura?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            fac.Estado = EstadoFactura.Anulada;

            Cotizacion? cot = _cotizaciones.FirstOrDefault(c => c.Id == fac.CotizacionId);
            if (cot != null)
            {
                cot.Estado = EstadoCotizacion.Activa;
                _dmCot.Save(_cotizaciones);
            }

            _dmFac.Save(_facturas);
            CargarGrid();
        }

        private void CargarGrid()
        {
            _facturas = _dmFac.GetAll();
            _cotizaciones = _dmCot.GetAll();
            _clientes = _dmCli.GetAll();
            _terrenos = _dmTer.GetAll();
            _materiales = _dmMat.GetAll();

            Vista.dvgFacturas.DataSource = null;
            Vista.dvgFacturas.DataSource = _facturas.Select(f =>
            {
                var cot = _cotizaciones.FirstOrDefault(c => c.Id == f.CotizacionId);
                return new
                {
                    f.Id,
                    Codigo = f.CodigoFiscal,
                    Cliente = _clientes.FirstOrDefault(c => c.Id == f.ClienteId)?.Nombre ?? "N/A",
                    Terreno = cot != null
                        ? _terrenos.FirstOrDefault(t => t.Id == cot.TerrenoId)?.Nombre ?? "N/A": "N/A",
                    Total = f.Total.ToString("C2", CultureInfo.GetCultureInfo("es-CO")),
                    Fecha = f.FechaEmision.ToString("dd/MM/yyyy"),
                    Estado = f.Estado.ToString()
                };
            }).ToList();

            if (Vista.dvgFacturas.Columns.Contains("Id"))
                Vista.dvgFacturas.Columns["Id"].Visible = false;

            EstilizarGrid();
            AgregarColumnasAccion();
            AplicarColoresEstado();
        }

        private void EstilizarGrid()
        {
            Vista.dvgFacturas.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;
            Vista.dvgFacturas.ColumnHeadersDefaultCellStyle.BackColor =Color.FromArgb(240, 240, 240);
            Vista.dvgFacturas.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Vista.dvgFacturas.EnableHeadersVisualStyles = false;
            Vista.dvgFacturas.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            Vista.dvgFacturas.RowTemplate.Height = 32;
            Vista.dvgFacturas.BackgroundColor = Color.White;
        }

        private void AgregarColumnasAccion()
        {
            if (Vista.dvgFacturas.Columns.Contains("ColDescargar"))
                Vista.dvgFacturas.Columns.Remove("ColDescargar");
            if (Vista.dvgFacturas.Columns.Contains("ColAnular"))
                Vista.dvgFacturas.Columns.Remove("ColAnular");

            Vista.dvgFacturas.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "ColDescargar",
                HeaderText = "",
                Text = "⬇ Descargar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 110,
                DefaultCellStyle =
                {
                    BackColor = Color.FromArgb(16, 185, 129),
                    ForeColor = Color.White,
                    Font      = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            Vista.dvgFacturas.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "ColAnular",
                HeaderText = "",
                Text = "Anular",
                UseColumnTextForButtonValue = false,
                FlatStyle = FlatStyle.Flat,
                Width = 80,
                DefaultCellStyle =
                {
                    Font      = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
        }

        private void AplicarColoresEstado()
        {
            foreach (DataGridViewRow row in Vista.dvgFacturas.Rows)
            {
                string estado = row.Cells["Estado"].Value?.ToString() ?? "";
                if (estado == "Anulada")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 60, 60);
                    row.DefaultCellStyle.Font =
                        new Font("Segoe UI", 9.5F, FontStyle.Italic);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(20, 130, 60);
                }
            }
        }

        private void Buscar()
        {
            string termino = Vista.txtBuscarFacturas.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termino)) { CargarGrid(); return; }

            Vista.dvgFacturas.DataSource = null;
            Vista.dvgFacturas.DataSource = _facturas
                .Where(f =>
                    f.CodigoFiscal.ToLower().Contains(termino) ||
                    (_clientes.FirstOrDefault(c => c.Id == f.ClienteId)?.Nombre ?? "")
                        .ToLower().Contains(termino) ||
                    f.Estado.ToString().ToLower().Contains(termino))
                .Select(f =>
                {
                    var cot = _cotizaciones.FirstOrDefault(c => c.Id == f.CotizacionId);
                    return new
                    {
                        f.Id,
                        Codigo = f.CodigoFiscal,
                        Cliente = _clientes.FirstOrDefault(c => c.Id == f.ClienteId)?.Nombre ?? "N/A",
                        Terreno = cot != null
                            ? _terrenos.FirstOrDefault(t => t.Id == cot.TerrenoId)?.Nombre ?? "N/A"
                            : "N/A",
                        Total = f.Total.ToString("C2", CultureInfo.GetCultureInfo("es-CO")),
                        Fecha = f.FechaEmision.ToString("dd/MM/yyyy"),
                        Estado = f.Estado.ToString()
                    };
                }).ToList();

            if (Vista.dvgFacturas.Columns.Contains("Id"))
                Vista.dvgFacturas.Columns["Id"].Visible = false;

            EstilizarGrid();
            AgregarColumnasAccion();
            AplicarColoresEstado();
        }

        public List<Factura> Listar()
        {
            _facturas = _dmFac.GetAll();
            return _facturas;
        }
    }
}
