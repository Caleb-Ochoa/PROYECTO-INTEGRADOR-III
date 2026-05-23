using System;
using System.Collections.Generic;
using System.Text;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Cotizacion
    {
        public Guid Id { get; set; }

        public Cliente Cliente { get; set; }

        public Terreno Terreno { get; set; }

        public Material Material { get; set; }

        public double Volumen { get; set; }

        public double PrecioUnitario { get; set; }

        public double CostoTotal { get; set; }

        public EstadoCotizacion Estado { get; set; }

        public DateTime Fecha { get; set; }

        public Cotizacion(
            Cliente cliente,
            Terreno terreno,
            Material material,
            double volumen,
            EstadoCotizacion estado)
        {
            Id = Guid.NewGuid();

            Cliente = cliente;

            Terreno = terreno;

            Material = material;

            Volumen = volumen;

            PrecioUnitario = material.CostoMetroCubico;

            CostoTotal = Volumen * PrecioUnitario;

            Estado = estado;

            Fecha = DateTime.Now;
        }

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Cliente: {Cliente.Nombre}\n" +
                   $"Terreno: {Terreno.Nombre}\n" +
                   $"Material: {Material.Nombre}\n" +
                   $"Volumen: {Volumen}\n" +
                   $"Precio Unitario: {PrecioUnitario}\n" +
                   $"Costo Total: {CostoTotal}\n" +
                   $"Estado: {Estado}\n" +
                   $"Fecha: {Fecha}";
        }
    }
}
