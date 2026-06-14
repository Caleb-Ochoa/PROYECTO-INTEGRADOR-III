using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal CostoMetroCubico { get; set; }

        public Material() { }
        public Material(int id, string nombre, decimal costo)
        { Id = id; Nombre = nombre; CostoMetroCubico = costo; }

        public override string ToString() =>
            $"{Id}|{Nombre}|{CostoMetroCubico.ToString(System.Globalization.CultureInfo.InvariantCulture)}";

        public static Material FromText(string line)
        {
            string[] p = line.Split('|');
            if (p.Length != 3)
                throw new FormatException($"Material inválido: {line}");
            return new Material
            {
                Id = int.Parse(p[0]),
                Nombre = p[1],
                CostoMetroCubico = decimal.Parse(p[2], System.Globalization.CultureInfo.InvariantCulture)
            };
        } 
    }
}
