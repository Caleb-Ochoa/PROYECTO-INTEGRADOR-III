using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Factura
    {
        public Guid Id { get; set; }

        public string NumeroFactura { get; set; }

        public Cotizacion Cotizacion { get; set; }

        public Cliente Cliente { get; set; }

        public double Total { get; set; }

        public EstadoFactura Estado { get; set; }

        public DateTime Fecha { get; set; }

        public Factura(
            string numeroFactura,
            Cotizacion cotizacion,
            Cliente cliente,
            EstadoFactura estado)
        {
            Id = Guid.NewGuid();

            NumeroFactura = numeroFactura;

            Cotizacion = cotizacion;

            Cliente = cliente;

            Total = cotizacion.CostoTotal;

            Estado = estado;

            Fecha = DateTime.Now;
        }

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Número Factura: {NumeroFactura}\n" +
                   $"Cliente: {Cliente.Nombre}\n" +
                   $"Total: {Total}\n" +
                   $"Estado: {Estado}\n" +
                   $"Fecha: {Fecha}";
        }
    }
}
