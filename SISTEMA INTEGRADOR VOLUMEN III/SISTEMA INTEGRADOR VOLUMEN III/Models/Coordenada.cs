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

        public Coordenada()
        {
        }

        public Coordenada(
            int id,
            double x,
            double y,
            double z)
        {
            Id = id;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
