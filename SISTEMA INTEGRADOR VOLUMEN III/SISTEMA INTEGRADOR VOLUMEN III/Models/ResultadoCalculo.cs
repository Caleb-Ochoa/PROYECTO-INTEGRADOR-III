using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class ResultadoCalculo
    {
        public double Area { get; set; }

        public double Volumen { get; set; }

        public DateTime Fecha { get; set; }

        public ResultadoCalculo(double area, double volumen)
        {
            Area = area;
            Volumen = volumen;
            Fecha = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Área: {Area}\n" +
                   $"Volumen: {Volumen}\n" +
                   $"Fecha: {Fecha}";
        }
    }
}
