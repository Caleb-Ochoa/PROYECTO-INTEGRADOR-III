using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Material
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public double CostoMetroCubico { get; set; }

        public bool Estado { get; set; }

        public Material(string nombre, double costoMetroCubico, bool estado)
        {
            Id = Guid.NewGuid();

            Nombre = nombre;

            CostoMetroCubico = costoMetroCubico;

            Estado = estado;
        }

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Nombre: {Nombre}\n" +
                   $"Costo por m³: {CostoMetroCubico}\n" +
                   $"Estado: {(Estado ? "Disponible" : "No disponible")}";
        }
    }
}
