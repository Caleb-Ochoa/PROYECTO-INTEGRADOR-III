using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Material
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal CostoMetroCubico { get; set; }

        public Material()
        {
            Nombre = string.Empty;
        }

        public Material(
            int id,
            string nombre,
            decimal costoMetroCubico)
        {
            Id = id;
            Nombre = nombre;
            CostoMetroCubico = costoMetroCubico;
        }
    }
}
