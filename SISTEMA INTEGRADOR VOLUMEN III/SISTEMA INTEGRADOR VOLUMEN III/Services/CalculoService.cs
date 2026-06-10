using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Services
{
    internal class CalculoService : ICalculoService
    {
        /// <summary>
        /// Calcula el volumen del terreno usando la fórmula de la Pirámide Truncada
        /// (método de prismoide) con las coordenadas Z como alturas.
        /// El área se calcula con la fórmula de Shoelace (Gauss) sobre X e Y.
        public ResultadoCalculo Calcular(Terreno terreno, Material material)
        {
            if (terreno.Coordenadas.Count < 3)
                throw new InvalidOperationException("Se necesitan al menos 3 coordenadas para calcular.");

            double area = CalcularAreaShoelace(terreno.Coordenadas);
            double zProm = 0;
            foreach (var c in terreno.Coordenadas) zProm += c.Z;
            zProm /= terreno.Coordenadas.Count;

            double volumen = area * zProm;
            decimal costoTotal = (decimal)volumen * material.CostoMetroCubico;

            return new ResultadoCalculo(area, volumen, costoTotal, "Prismoide + Shoelace");
        }

        /// <summary>
        /// Fórmula de Shoelace — calcula el área de un polígono
        /// dado sus vértices en orden (X, Y).
        /// </summary>
        public static double CalcularAreaShoelace(List<Coordenada> coords)
        {
            int n = coords.Count;
            double area = 0;
            for (int i = 0; i < n; i++)
            {
                int j = (i + 1) % n;
                area += coords[i].X * coords[j].Y;
                area -= coords[j].X * coords[i].Y;
            }
            return Math.Abs(area) / 2.0;
        }
    }
}
