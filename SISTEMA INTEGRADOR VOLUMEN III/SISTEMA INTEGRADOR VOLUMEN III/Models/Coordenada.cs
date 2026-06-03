using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Coordenada
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Coordenada() { }
        public Coordenada(int id, double x, double y, double z)
        { Id = id; X = x; Y = y; Z = z; }

        // Formato: id;x;y;z (punto y coma interno para no chocar con el separador del Terreno)
        public override string ToString() =>
            $"{Id};{X:R};{Y:R};{Z:R}";

        public static Coordenada FromText(string s)
        {
            string[] p = s.Split(';');
            if (p.Length != 4)
                throw new FormatException($"Coordenada inválida: {s}");
            return new Coordenada(int.Parse(p[0]),
                double.Parse(p[1], System.Globalization.CultureInfo.InvariantCulture),
                double.Parse(p[2], System.Globalization.CultureInfo.InvariantCulture),
                double.Parse(p[3], System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}
