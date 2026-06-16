using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Services;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Controller
{
    internal class CtlCotizacion
    {
        public Cotizaciones Vista { get; set; }
        private readonly CodigoFiscalGenerator _codigoGen;
        private DataManager<Factura> dataManagerFac;
        private DataManager<Cotizacion> dataManagerCot;
        private DataManager<Cliente> dataManagerCli;
        private DataManager<Terreno> dataManagerTer;
        private DataManager<Material> dataManagerMat;
        private ICalculoService calculoService;

        private List<Cotizacion> cotizaciones;
        private List<Cliente> clientes;
        private List<Terreno> terrenos;
        private List<Material> materiales;

        public CtlCotizacion(
            DataManager<Cotizacion> dmCot,
            DataManager<Cliente> dmCli,
            DataManager<Terreno> dmTer,
            DataManager<Material> dmMat,
            DataManager<Factura> dmFac,
            ICalculoService calculo,
            CodigoFiscalGenerator codigoGen,
            Cotizaciones vista)
        {
            dataManagerCot = dmCot;
            dataManagerCli = dmCli;
            dataManagerTer = dmTer;
            dataManagerMat = dmMat;
            dataManagerFac = dmFac;
            calculoService = calculo;
            _codigoGen = codigoGen;
            Vista = vista;

            cotizaciones = dataManagerCot.GetAll();
            clientes = dataManagerCli.GetAll();
            terrenos = dataManagerTer.GetAll();
            materiales = dataManagerMat.GetAll();

            CargarGrid();

            Vista.dvgCotizaciones.CellPainting += (sender, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                string colName = Vista.dvgCotizaciones.Columns[e.ColumnIndex].Name;
                string estado = Vista.dvgCotizaciones.Rows[e.RowIndex]
                    .Cells["Estado"].Value?.ToString() ?? "";

                if (colName == "ColFacturar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    Color btnColor = estado == "Activa"
                        ? Color.FromArgb(234, 179, 8)    
                        : Color.FromArgb(200, 200, 200);  

                    string btnText = estado == "Facturada" ? "✓ Facturada" : "Facturar";

                    using var brush = new SolidBrush(btnColor);
                    var rect = new Rectangle(
                        e.CellBounds.X + 2, e.CellBounds.Y + 2,
                        e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                    e.Graphics.FillRectangle(brush, rect);

                    using var txtBrush = new SolidBrush(Color.White);
                    var fmt = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString(btnText,
                        new Font("Segoe UI", 9F, FontStyle.Bold),
                        txtBrush, rect, fmt);

                    e.Handled = true;
                }
                else if (colName == "ColAnular")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    Color btnColor = estado == "Cancelada"
                        ? Color.FromArgb(160, 160, 160)
                        : Color.FromArgb(220, 38, 38);

                    string btnText = estado == "Cancelada" ? "Anulada" : "Anular";

                    using var brush = new SolidBrush(btnColor);
                    var rect = new Rectangle(
                        e.CellBounds.X + 2, e.CellBounds.Y + 2,
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
                }
            };

            Vista.btnAgregarCotizacion.Click += (sender, e) =>
            {
                NuevaCotizacion();
            };

            Vista.btnBuscarCotizaciones.Click += (sender, e) =>
            {
                Buscar();
            };

            Vista.txtBuscarCotizaciones.TextChanged += (sender, e) =>
            {
                Buscar();
            };

            Vista.btnLimpiarCotizaciones.Click += (sender, e) =>
            {
                Vista.txtBuscarCotizaciones.Clear();
                CargarGrid();
            };

            Vista.dvgCotizaciones.CellClick += (sender, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                string col = Vista.dvgCotizaciones.Columns[e.ColumnIndex].Name;
                var celda = Vista.dvgCotizaciones.Rows[e.RowIndex].Cells["Id"];
                if (celda?.Value == null) return;

                int id = (int)celda.Value;

                if (col == "ColVer")
                    VerCotizacion(id);
                else if (col == "ColFacturar")
                    FacturarCotizacion(id);
                else if (col == "ColAnular")
                    AnularCotizacion(id);
            };
        }
        private void NuevaCotizacion()
        {
            clientes = dataManagerCli.GetAll();
            terrenos = dataManagerTer.GetAll();
            materiales = dataManagerMat.GetAll();

            if (!clientes.Any())
            { MessageBox.Show("No hay clientes registrados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!terrenos.Any())
            { MessageBox.Show("No hay terrenos registrados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!materiales.Any())
            { MessageBox.Show("No hay materiales registrados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var sel = Vista.MostrarPopupNuevaCotizacion(clientes, terrenos, materiales);
            if (sel == null) return;

            var (clienteId, terrenoId, materialId) = sel.Value;

            try
            {
                Terreno? terreno = terrenos.FirstOrDefault(t => t.Id == terrenoId);
                Material? material = materiales.FirstOrDefault(m => m.Id == materialId);

                if (terreno == null || material == null)
                    throw new InvalidOperationException("Terreno o material no encontrado.");

                if (terreno.Coordenadas.Count < 3)
                    throw new InvalidOperationException(
                        $"El terreno '{terreno.Nombre}' tiene {terreno.Coordenadas.Count} coordenadas. " +
                        "Se necesitan al menos 3 para calcular el volumen.");

                var resultado = calculoService.Calcular(terreno, material);

                var cot = new Cotizacion
                {
                    Id = dataManagerCot.GetNextId(),
                    ClienteId = clienteId,
                    TerrenoId = terrenoId,
                    MaterialId = materialId,
                    Volumen = resultado.Volumen,
                    CostoTotal = resultado.CostoTotal,
                    Fecha = DateTime.Now,
                    Estado = EstadoCotizacion.Activa
                };

                cotizaciones.Add(cot);
                Save();

                MessageBox.Show(
                    $"Cotización generada exitosamente.\n\n" +
                    $"Método: {resultado.MetodoUsado}\n" +
                    $"Volumen: {resultado.Volumen:F4} m³\n" +
                    $"Costo total: {resultado.CostoTotal:C2}",
                    "Cotización creada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerCotizacion(int id)
        {
            Cotizacion? cot = cotizaciones.FirstOrDefault(c => c.Id == id);
            if (cot == null) return;

            Cliente? cli = clientes.FirstOrDefault(c => c.Id == cot.ClienteId);
            Terreno? ter = terrenos.FirstOrDefault(t => t.Id == cot.TerrenoId);
            Material? mat = materiales.FirstOrDefault(m => m.Id == cot.MaterialId);

            string detalle =
                $"ID Cotización:  {cot.Id}\n" +
                $"Cliente:        {cli?.Nombre ?? "N/A"}\n" +
                $"Terreno:        {ter?.Nombre ?? "N/A"}\n" +
                $"Material:       {mat?.Nombre ?? "N/A"}\n" +
                $"Costo m³:       {mat?.CostoMetroCubico.ToString("C2") ?? "N/A"}\n" +
                $"Volumen:        {cot.Volumen:F4} m³\n" +
                $"Costo total:    {cot.CostoTotal:C2}\n" +
                $"Fecha:          {cot.Fecha:dd/MM/yyyy HH:mm}\n" +
                $"Estado:         {cot.Estado}";

            MessageBox.Show(detalle, "Detalle de cotización", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AnularCotizacion(int id)
        {
            Cotizacion? cot = cotizaciones.FirstOrDefault(c => c.Id == id);
            if (cot == null) return;

            if (cot.Estado == EstadoCotizacion.Cancelada)
            {
                return;
            }

            if (MessageBox.Show("¿Está seguro de anular esta cotización?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            cot.Estado = EstadoCotizacion.Cancelada;
            Save();
        }

        private void Save()
        {
            dataManagerCot.Save(cotizaciones);
            CargarGrid();
        }

        public List<Cotizacion> Listar()
        {
            cotizaciones = dataManagerCot.GetAll();
            return cotizaciones;
        }

        private void CargarGrid()
        {
            cotizaciones = dataManagerCot.GetAll();
            clientes = dataManagerCli.GetAll();
            terrenos = dataManagerTer.GetAll();
            materiales = dataManagerMat.GetAll();

            Vista.dvgCotizaciones.DataSource = null;
            Vista.dvgCotizaciones.DataSource = cotizaciones.Select(c => new
            {
                c.Id,
                Cliente = clientes.FirstOrDefault(x => x.Id == c.ClienteId)?.Nombre ?? "N/A",
                Terreno = terrenos.FirstOrDefault(x => x.Id == c.TerrenoId)?.Nombre ?? "N/A",
                Material = materiales.FirstOrDefault(x => x.Id == c.MaterialId)?.Nombre ?? "N/A",
                Volumen = $"{c.Volumen:F2} m³",
                Costo = c.CostoTotal.ToString("C2", CultureInfo.GetCultureInfo("es-CO")),
                Fecha = c.Fecha.ToString("dd/MM/yyyy"),
                Estado = c.Estado.ToString()
            }).ToList();

            if (Vista.dvgCotizaciones.Columns.Contains("Id"))
                Vista.dvgCotizaciones.Columns["Id"].Visible = false;

            EstilizarGrid();
            AgregarColumnasAccion();
            AplicarColoresEstado();
        }

        private void EstilizarGrid()
        {
            Vista.dvgCotizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Vista.dvgCotizaciones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            Vista.dvgCotizaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Vista.dvgCotizaciones.EnableHeadersVisualStyles = false;
            Vista.dvgCotizaciones.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            Vista.dvgCotizaciones.RowTemplate.Height = 32;
            Vista.dvgCotizaciones.BackgroundColor = Color.White;
        }

        private void AgregarColumnasAccion()
        {
            if (Vista.dvgCotizaciones.Columns.Contains("ColVer"))
                Vista.dvgCotizaciones.Columns.Remove("ColVer");
            if (Vista.dvgCotizaciones.Columns.Contains("ColFacturar"))
                Vista.dvgCotizaciones.Columns.Remove("ColFacturar");
            if (Vista.dvgCotizaciones.Columns.Contains("ColAnular"))
                Vista.dvgCotizaciones.Columns.Remove("ColAnular");

            Vista.dvgCotizaciones.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "ColVer",
                HeaderText = "",
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 60,
                DefaultCellStyle =
        {
            BackColor = Color.FromArgb(37, 99, 235),
            ForeColor = Color.White,
            Font      = new Font("Segoe UI", 9F, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });

            Vista.dvgCotizaciones.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "ColFacturar",
                HeaderText = "",
                Text = "Facturar",
                UseColumnTextForButtonValue = false,
                FlatStyle = FlatStyle.Flat,
                Width = 90,
                DefaultCellStyle =
        {
            Font      = new Font("Segoe UI", 9F, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });

            Vista.dvgCotizaciones.Columns.Add(new DataGridViewButtonColumn
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
            foreach (DataGridViewRow row in Vista.dvgCotizaciones.Rows)
            {
                string estado = row.Cells["Estado"].Value?.ToString() ?? "";

                if (estado == "Cancelada")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 60, 60);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);

                    if (row.Cells["ColAnular"] is DataGridViewButtonCell btnAnular)
                    {
                        btnAnular.Style.BackColor = Color.FromArgb(200, 200, 200);
                        btnAnular.Style.ForeColor = Color.FromArgb(150, 150, 150);
                        btnAnular.Value = "Anulada";
                    }
                }
                else if (estado == "Facturada")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(235, 245, 255);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(40, 80, 160);
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
            string termino = Vista.txtBuscarCotizaciones.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termino)) { CargarGrid(); return; }

            Vista.dvgCotizaciones.DataSource = null;
            Vista.dvgCotizaciones.DataSource = cotizaciones
                .Where(c =>
                    (clientes.FirstOrDefault(x => x.Id == c.ClienteId)?.Nombre ?? "").ToLower().Contains(termino) ||
                    (terrenos.FirstOrDefault(x => x.Id == c.TerrenoId)?.Nombre ?? "").ToLower().Contains(termino) ||
                    c.Estado.ToString().ToLower().Contains(termino)).Select(c => new
                    {
                        c.Id,
                        Cliente = clientes.FirstOrDefault(x => x.Id == c.ClienteId)?.Nombre ?? "N/A",
                        Terreno = terrenos.FirstOrDefault(x => x.Id == c.TerrenoId)?.Nombre ?? "N/A",
                        Material = materiales.FirstOrDefault(x => x.Id == c.MaterialId)?.Nombre ?? "N/A",
                        Volumen = $"{c.Volumen:F2} m³",
                        Costo = c.CostoTotal.ToString("C2", CultureInfo.GetCultureInfo("es-CO")),
                        Fecha = c.Fecha.ToString("dd/MM/yyyy"),
                        Estado = c.Estado.ToString()
                    }).ToList();

            if (Vista.dvgCotizaciones.Columns.Contains("Id")) Vista.dvgCotizaciones.Columns["Id"].Visible = false;

            EstilizarGrid();
            AgregarColumnasAccion();
            AplicarColoresEstado();
        }

        private void FacturarCotizacion(int id)
        {
            Cotizacion? cot = cotizaciones.FirstOrDefault(c => c.Id == id);
            if (cot == null) return;

            if (cot.Estado != EstadoCotizacion.Activa)
            {
                MessageBox.Show(
                    cot.Estado == EstadoCotizacion.Facturada
                        ? "Esta cotización ya fue facturada."
                        : "No se puede facturar una cotización cancelada.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    "¿Desea generar una factura para esta cotización?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            try
            {
                string codigo = _codigoGen.Generar();

                Factura factura = new Factura
                {
                    Id = dataManagerFac.GetNextId(),
                    CodigoFiscal = codigo,
                    CotizacionId = cot.Id,
                    ClienteId = cot.ClienteId,
                    Total = cot.CostoTotal,
                    FechaEmision = DateTime.Now,
                    Estado = EstadoFactura.Emitida
                };

                var facturas = dataManagerFac.GetAll();
                facturas.Add(factura);
                dataManagerFac.Save(facturas);

                cot.Estado = EstadoCotizacion.Facturada;
                dataManagerCot.Save(cotizaciones);

                CargarGrid();

                MessageBox.Show(
                    $"Factura generada exitosamente.\n" +$"Código: {codigo}\n" +$"Total: {factura.Total:C2}",
                    "Factura creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}