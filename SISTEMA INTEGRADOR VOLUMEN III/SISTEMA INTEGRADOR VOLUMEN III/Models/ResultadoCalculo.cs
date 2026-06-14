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
        public string MetodoUsado { get; set; } = string.Empty;

        public ResultadoCalculo() { }
        public ResultadoCalculo(double area, double volumen, decimal costoTotal, string metodo)
        { Area = area; Volumen = volumen; CostoTotal = costoTotal; MetodoUsado = metodo; }
    }
}