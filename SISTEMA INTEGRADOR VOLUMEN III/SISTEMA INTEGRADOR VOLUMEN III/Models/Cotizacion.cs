using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    public class Cotizacion
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TerrenoId { get; set; }
        public int MaterialId { get; set; }
        public double Volumen { get; set; }
        public decimal CostoTotal { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public EstadoCotizacion Estado { get; set; } = EstadoCotizacion.Activa;

        public Cotizacion() { }
        public Cotizacion(int id, int clienteId, int terrenoId, int materialId,
            double volumen, decimal costoTotal, DateTime fecha, EstadoCotizacion estado)
        {
            Id = id; ClienteId = clienteId; TerrenoId = terrenoId;
            MaterialId = materialId; Volumen = volumen; CostoTotal = costoTotal;
            Fecha = fecha; Estado = estado;
        }

        public override string ToString() =>
            $"{Id}|{ClienteId}|{TerrenoId}|{MaterialId}|" +
            $"{Volumen.ToString("R", CultureInfo.InvariantCulture)}|" +
            $"{CostoTotal.ToString(CultureInfo.InvariantCulture)}|" +
            $"{Fecha:O}|{Estado}";

        public static Cotizacion FromText(string line)
        {
            string[] p = line.Split('|');
            if (p.Length != 8)
                throw new FormatException($"Cotización inválida ({p.Length} campos): {line}");
            return new Cotizacion
            {
                Id = int.Parse(p[0]),
                ClienteId = int.Parse(p[1]),
                TerrenoId = int.Parse(p[2]),
                MaterialId = int.Parse(p[3]),
                Volumen = double.Parse(p[4], CultureInfo.InvariantCulture),
                CostoTotal = decimal.Parse(p[5], CultureInfo.InvariantCulture),
                Fecha = DateTime.Parse(p[6]),
                Estado = (EstadoCotizacion)Enum.Parse(typeof(EstadoCotizacion), p[7])
            };
        }
    }
}
