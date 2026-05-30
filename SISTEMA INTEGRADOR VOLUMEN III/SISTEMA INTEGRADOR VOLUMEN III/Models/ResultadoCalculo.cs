using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class ResultadoCalculo
    {
        public double Area { get; set; }

        public double Volumen { get; set; }
        public decimal CostoTotal { get; set; }

        public ResultadoCalculo()
        {
        }

        public ResultadoCalculo(
            double area,
            double volumen,
            decimal costoTotal)
        {
            Area = area;
            Volumen = volumen;
            CostoTotal = costoTotal;
        }
    }
}
