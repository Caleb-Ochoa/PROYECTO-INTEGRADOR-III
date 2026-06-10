using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Services
{
    internal class CalculoService : ICalculoService
    {
        // ── Método principal — elige el mejor método según los puntos ─────
        public ResultadoCalculo Calcular(Terreno terreno, Material material)
        {
            if (terreno.Coordenadas.Count < 3)
                throw new InvalidOperationException(
                    "Se necesitan al menos 3 coordenadas.");

            // Con 6+ puntos usamos Mínimos Cuadrados + Integral Doble (más preciso)
            // Con menos puntos usamos Shoelace + Prismoide
            if (terreno.Coordenadas.Count >= 6)
                return CalcularConModeloCuadratico(terreno, material);
            else
                return CalcularConShoelace(terreno, material);
        }

        // ── MÉTODO 1: Mínimos Cuadrados + Integral Doble ──────────────────
        // Ajusta z = ax²+by²+cxy+dx+ey+f y luego integra numéricamente
        private ResultadoCalculo CalcularConModeloCuadratico(
            Terreno terreno, Material material)
        {
            var coef = AjustarMinCuadrados(terreno.Coordenadas);

            double xMin = terreno.Coordenadas.Min(c => c.X);
            double xMax = terreno.Coordenadas.Max(c => c.X);
            double yMin = terreno.Coordenadas.Min(c => c.Y);
            double yMax = terreno.Coordenadas.Max(c => c.Y);

            double volumen = IntegralDoble(coef, xMin, xMax, yMin, yMax, pasos: 100);
            double area = (xMax - xMin) * (yMax - yMin);
            decimal costo = (decimal)Math.Abs(volumen) * material.CostoMetroCubico;

            return new ResultadoCalculo(area, Math.Abs(volumen), costo,
                "Mínimos Cuadrados + Integral Doble");
        }

        // ── MÉTODO 2: Shoelace + Prismoide (fallback con pocos puntos) ────
        private ResultadoCalculo CalcularConShoelace(
            Terreno terreno, Material material)
        {
            double area = CalcularAreaShoelace(terreno.Coordenadas);
            double zProm = terreno.Coordenadas.Average(c => c.Z);
            double volumen = area * zProm;
            decimal costo = (decimal)Math.Abs(volumen) * material.CostoMetroCubico;

            return new ResultadoCalculo(area, Math.Abs(volumen), costo,
                "Shoelace + Prismoide");
        }

        // ── Ajuste por Mínimos Cuadrados ──────────────────────────────────
        // Resuelve el sistema [x²,y²,xy,x,y,1] para cada punto
        // Retorna [A,B,C,D,E,F]
        public static double[] AjustarMinCuadrados(List<Coordenada> pts)
        {
            int n = pts.Count;
            int m = 6; // número de coeficientes

            // Matriz A (n x 6) y vector b (n x 1)
            double[,] A = new double[n, m];
            double[] b = new double[n];

            for (int i = 0; i < n; i++)
            {
                double x = pts[i].X, y = pts[i].Y;
                A[i, 0] = x * x;
                A[i, 1] = y * y;
                A[i, 2] = x * y;
                A[i, 3] = x;
                A[i, 4] = y;
                A[i, 5] = 1;
                b[i] = pts[i].Z;
            }

            // Normal equations: (Aᵀ·A)·coef = Aᵀ·b
            double[,] AtA = MultiplicarMatrices(Transponer(A, n, m), m, n, A, n, m);
            double[] Atb = MultiplicarMatrizVector(Transponer(A, n, m), m, n, b);

            return GaussJordan(AtA, Atb, m);
        }

        // ── Integral Doble por Sumas de Riemann ───────────────────────────
        public static double IntegralDoble(double[] coef,
            double xMin, double xMax, double yMin, double yMax, int pasos = 100)
        {
            double dx = (xMax - xMin) / pasos;
            double dy = (yMax - yMin) / pasos;
            double vol = 0;

            for (int i = 0; i < pasos; i++)
            {
                double x = xMin + (i + 0.5) * dx;
                for (int j = 0; j < pasos; j++)
                {
                    double y = yMin + (j + 0.5) * dy;
                    double z = EvaluarModelo(coef, x, y);
                    vol += z * dx * dy;
                }
            }
            return vol;
        }

        public static double EvaluarModelo(double[] c, double x, double y) =>
            c[0] * x * x + c[1] * y * y + c[2] * x * y + c[3] * x + c[4] * y + c[5];

        // ── Shoelace ──────────────────────────────────────────────────────
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

        // ── Álgebra lineal básica ─────────────────────────────────────────
        private static double[,] Transponer(double[,] M, int filas, int cols)
        {
            double[,] T = new double[cols, filas];
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                    T[j, i] = M[i, j];
            return T;
        }

        private static double[,] MultiplicarMatrices(
            double[,] A, int rA, int cA,
            double[,] B, int rB, int cB)
        {
            double[,] R = new double[rA, cB];
            for (int i = 0; i < rA; i++)
                for (int j = 0; j < cB; j++)
                    for (int k = 0; k < cA; k++)
                        R[i, j] += A[i, k] * B[k, j];
            return R;
        }

        private static double[] MultiplicarMatrizVector(
            double[,] A, int rA, int cA, double[] v)
        {
            double[] r = new double[rA];
            for (int i = 0; i < rA; i++)
                for (int j = 0; j < cA; j++)
                    r[i] += A[i, j] * v[j];
            return r;
        }

        // Eliminación de Gauss-Jordan para resolver Ax=b
        private static double[] GaussJordan(double[,] A, double[] b, int n)
        {
            double[,] M = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) M[i, j] = A[i, j];
                M[i, n] = b[i];
            }

            for (int col = 0; col < n; col++)
            {
                // Pivoteo parcial
                int max = col;
                for (int row = col + 1; row < n; row++)
                    if (Math.Abs(M[row, col]) > Math.Abs(M[max, col])) max = row;
                for (int k = 0; k <= n; k++)
                    (M[col, k], M[max, k]) = (M[max, k], M[col, k]);

                double piv = M[col, col];
                if (Math.Abs(piv) < 1e-12) continue;

                for (int k = col; k <= n; k++) M[col, k] /= piv;

                for (int row = 0; row < n; row++)
                {
                    if (row == col) continue;
                    double factor = M[row, col];
                    for (int k = col; k <= n; k++)
                        M[row, k] -= factor * M[col, k];
                }
            }

            double[] x = new double[n];
            for (int i = 0; i < n; i++) x[i] = M[i, n];
            return x;
        }
    }
}
