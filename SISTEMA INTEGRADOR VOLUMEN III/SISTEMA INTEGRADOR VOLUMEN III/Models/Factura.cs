using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Factura
    {
        public int Id { get; set; }

        public string CodigoFiscal { get; set; }

        public int CotizacionId { get; set; }

        public decimal Total { get; set; }

        public DateTime FechaEmision { get; set; }

        public EstadoFactura Estado { get; set; }


        public Factura()
        {
            CodigoFiscal = string.Empty;
            FechaEmision = DateTime.Now;
            Estado = EstadoFactura.Emitida;
        }


        public Factura(
            int id,
            string codigoFiscal,
            int cotizacionId,
            decimal total,
            DateTime fechaEmision,
            EstadoFactura estado)
        {
            Id = id;
            CodigoFiscal = codigoFiscal;
            CotizacionId = cotizacionId;
            Total = total;
            FechaEmision = fechaEmision;
            Estado = estado;
        }

    }
}
