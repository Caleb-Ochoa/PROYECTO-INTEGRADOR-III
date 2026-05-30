using System;
using System.Collections.Generic;
using System.Text;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Cotizacion
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int TerrenoId { get; set; }

        public int MaterialId { get; set; }

        public double Volumen { get; set; }

        public decimal CostoTotal { get; set; }

        public DateTime Fecha { get; set; }

        public EstadoCotizacion Estado { get; set; }


        public Cotizacion()
        {
            Fecha = DateTime.Now;
            Estado = EstadoCotizacion.Activa;
        }


        public Cotizacion(
            int id,
            int clienteId,
            int terrenoId,
            int materialId,
            double volumen,
            decimal costoTotal,
            DateTime fecha,
            EstadoCotizacion estado)
        {
            Id = id;
            ClienteId = clienteId;
            TerrenoId = terrenoId;
            MaterialId = materialId;
            Volumen = volumen;
            CostoTotal = costoTotal;
            Fecha = fecha;
            Estado = estado;
        }
    }
}
