using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public string CodigoFiscal { get; set; } = string.Empty;
        public int CotizacionId { get; set; }
        public int ClienteId { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public EstadoFactura Estado { get; set; } = EstadoFactura.Emitida;

        public Factura() { }
        public Factura(int id, string codigoFiscal, int cotizacionId, int clienteId,
            decimal total, DateTime fechaEmision, EstadoFactura estado)
        {
            Id = id; CodigoFiscal = codigoFiscal; CotizacionId = cotizacionId;
            ClienteId = clienteId; Total = total; FechaEmision = fechaEmision; Estado = estado;
        }

        public override string ToString() =>
            $"{Id}|{CodigoFiscal}|{CotizacionId}|{ClienteId}|" +
            $"{Total.ToString(CultureInfo.InvariantCulture)}|{FechaEmision:O}|{Estado}";

        public static Factura FromText(string line)
        {
            string[] p = line.Split('|');
            if (p.Length != 7)
                throw new FormatException($"Factura inválida ({p.Length} campos): {line}");
            return new Factura
            {
                Id = int.Parse(p[0]),
                CodigoFiscal = p[1],
                CotizacionId = int.Parse(p[2]),
                ClienteId = int.Parse(p[3]),
                Total = decimal.Parse(p[4], CultureInfo.InvariantCulture),
                FechaEmision = DateTime.Parse(p[5]),
                Estado = (EstadoFactura)Enum.Parse(typeof(EstadoFactura), p[6])
            };
        }

    }
}
