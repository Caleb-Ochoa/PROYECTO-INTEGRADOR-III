using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces
{
    internal interface ICalculoService
    {
        ResultadoCalculo Calcular(
           Terreno terreno,
           Material material);
    }
}
