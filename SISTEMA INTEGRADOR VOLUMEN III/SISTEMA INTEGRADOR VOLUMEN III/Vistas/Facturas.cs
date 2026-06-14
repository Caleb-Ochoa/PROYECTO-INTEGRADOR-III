using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Windows.Forms;


namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    public partial class Facturas : Form
    {
        public Facturas()
        {
            InitializeComponent();
            Idioma.Aplicar(this);
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public void MostrarMensaje(string msg, bool esError = false)
        {
            MessageBox.Show(msg,
                esError ? "Error" : "Información",
                MessageBoxButtons.OK,
                esError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        // ── Descargar factura con QuestPDF ────────────────────────────────
        public void DescargarFacturaPDF(Factura factura, Cliente cliente,
            Cotizacion cotizacion, Terreno terreno, Material material)
        {
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Guardar factura como PDF",
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"Factura_{factura.CodigoFiscal}_{factura.FechaEmision:yyyyMMdd}.pdf"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                GenerarPDF(sfd.FileName, factura, cliente, cotizacion, terreno, material);
                MostrarMensaje($"Factura guardada correctamente en:\n{sfd.FileName}");

                // Abrir el PDF con el visor del sistema
                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo(sfd.FileName)
                    { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al generar el PDF:\n{ex.Message}", esError: true);
            }
        }

        private void GenerarPDF(string ruta, Factura factura, Cliente cliente,
            Cotizacion cotizacion, Terreno terreno, Material material)
        {
            QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(10));

                    // ── HEADER ────────────────────────────────────────────
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("🏗 SISTEMA INTEGRADOR VOL. III")
                                .Bold().FontSize(16).FontColor(Colors.Blue.Darken2);
                            col.Item().Text("Empresa de construcción y excavaciones")
                                .FontSize(9).FontColor(Colors.Grey.Medium);
                        });

                        row.ConstantItem(160).AlignRight().Column(col =>
                        {
                            col.Item().Text("FACTURA")
                                .Bold().FontSize(22).FontColor(Colors.Blue.Darken2);
                            col.Item().Text($"Código: {factura.CodigoFiscal}")
                                .FontSize(9).FontColor(Colors.Grey.Medium);
                            col.Item().Text($"Fecha: {factura.FechaEmision:dd/MM/yyyy HH:mm}")
                                .FontSize(9).FontColor(Colors.Grey.Medium);
                            col.Item().Background(
                                factura.Estado == Enums.EstadoFactura.Emitida
                                    ? Colors.Green.Lighten3 : Colors.Red.Lighten3)
                                .Padding(4)
                                .Text(factura.Estado.ToString())
                                .Bold().FontSize(9).FontColor(
                                    factura.Estado == Enums.EstadoFactura.Emitida
                                        ? Colors.Green.Darken3 : Colors.Red.Darken3);
                        });
                    });

                    page.Content().Column(col =>
                    {
                        col.Spacing(12);

                        // Línea separadora
                        col.Item().PaddingTop(8).LineHorizontal(2)
                            .LineColor(Colors.Blue.Darken2);

                        // ── DATOS DEL CLIENTE ─────────────────────────────
                        col.Item().Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                        {
                            c.Item().Text("INFORMACIÓN DEL CLIENTE")
                                .Bold().FontSize(9).FontColor(Colors.Grey.Medium);
                            c.Spacing(4);
                            c.Item().Row(r =>
                            {
                                r.RelativeItem().Column(cc =>
                                {
                                    cc.Item().Text($"Nombre: {cliente.Nombre}").Bold();
                                    cc.Item().Text($"Documento: {cliente.Documento}");
                                    cc.Item().Text($"Correo: {cliente.CorreoElectronico}");
                                });
                                r.RelativeItem().Column(cc =>
                                {
                                    cc.Item().Text($"Teléfono: {cliente.Telefono}");
                                    cc.Item().Text($"Dirección: {cliente.Direccion}");
                                });
                            });
                        });

                        // ── DETALLE DEL SERVICIO ──────────────────────────
                        col.Item().Text("DETALLE DEL SERVICIO")
                            .Bold().FontSize(9).FontColor(Colors.Grey.Medium);

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn(3);
                                cols.RelativeColumn(2);
                                cols.RelativeColumn(2);
                                cols.RelativeColumn(2);
                                cols.RelativeColumn(2);
                                cols.RelativeColumn(2);
                            });

                            // Encabezados
                            static IContainer HeaderCell(IContainer c) =>
                                c.Background(Colors.Blue.Darken2).Padding(6).AlignCenter();

                            table.Header(h =>
                            {
                                h.Cell().Element(HeaderCell).Text("Descripción")
                                    .Bold().FontColor(Colors.White);
                                h.Cell().Element(HeaderCell).Text("Terreno")
                                    .Bold().FontColor(Colors.White);
                                h.Cell().Element(HeaderCell).Text("Material")
                                    .Bold().FontColor(Colors.White);
                                h.Cell().Element(HeaderCell).Text("Volumen")
                                    .Bold().FontColor(Colors.White);
                                h.Cell().Element(HeaderCell).Text("Costo/m³")
                                    .Bold().FontColor(Colors.White);
                                h.Cell().Element(HeaderCell).Text("Total")
                                    .Bold().FontColor(Colors.White);
                            });

                            static IContainer DataCell(IContainer c) =>
                                c.BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                 .Padding(6).AlignCenter();

                            table.Cell().Element(DataCell)
                                .Text("Excavación y cálculo de volumen");
                            table.Cell().Element(DataCell).Text(terreno.Nombre);
                            table.Cell().Element(DataCell).Text(material.Nombre);
                            table.Cell().Element(DataCell)
                                .Text($"{cotizacion.Volumen:F4} m³");
                            table.Cell().Element(DataCell)
                                .Text($"{material.CostoMetroCubico:C2}");
                            table.Cell().Element(DataCell)
                                .Text($"{cotizacion.CostoTotal:C2}").Bold();
                        });

                        // ── TOTAL ─────────────────────────────────────────
                        col.Item().AlignRight().Background(Colors.Blue.Lighten4)
                            .Padding(12).Column(c =>
                            {
                                c.Item().Text("TOTAL A PAGAR")
                                    .FontSize(10).FontColor(Colors.Grey.Medium);
                                c.Item().Text($"{factura.Total:C2}")
                                    .Bold().FontSize(20).FontColor(Colors.Blue.Darken2);
                            });

                        // ── REFERENCIAS ───────────────────────────────────
                        col.Item().Background(Colors.Grey.Lighten4).Padding(8).Row(r =>
                        {
                            r.RelativeItem().Text($"ID Factura: #{factura.Id}  |  " +
                                $"ID Cotización: #{cotizacion.Id}  |  " +
                                $"Código Fiscal: {factura.CodigoFiscal}")
                                .FontSize(8).FontColor(Colors.Grey.Medium);
                        });
                    });

                    // ── FOOTER ────────────────────────────────────────────
                    page.Footer().AlignCenter().Column(c =>
                    {
                        c.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                        c.Item().PaddingTop(4).Text(
                            $"Documento generado el {DateTime.Now:dd/MM/yyyy HH:mm} — " +
                            "Sistema Integrador Volumen III — " +
                            "Este documento es válido como comprobante de pago.")
                            .FontSize(8).FontColor(Colors.Grey.Medium).AlignCenter();
                    });
                });
            }).GeneratePdf(ruta);
        }
    }
}
