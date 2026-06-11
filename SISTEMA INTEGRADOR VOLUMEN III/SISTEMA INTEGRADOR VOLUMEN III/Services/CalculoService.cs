using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Services
{
    internal class CalculoService : ICalculoService
    {
        // ── Método principal ──────────────────────────────────────────────
        // Con 6+ puntos: Mínimos Cuadrados + Integral Doble sobre área REAL (Shoelace)
        // Con 3-5 puntos: Triangulación TIN + suma de prismas (Delaunay manual)
        public ResultadoCalculo Calcular(Terreno terreno, Material material)
        {
            if (terreno.Coordenadas.Count < 3)
                throw new InvalidOperationException("Se necesitan al menos 3 coordenadas.");

            if (terreno.Coordenadas.Count >= 6)
                return CalcularConModeloCuadratico(terreno, material);
            else
                return CalcularConTIN(terreno, material);
        }

        // ── MÉTODO 1: Mínimos Cuadrados + Integral Doble sobre polígono REAL ──
        private ResultadoCalculo CalcularConModeloCuadratico(Terreno terreno, Material material)
        {
            var pts = terreno.Coordenadas;
            var coef = AjustarMinCuadrados(pts);

            // Área REAL del polígono (Shoelace con X e Y)
            double areaReal = CalcularAreaShoelace(pts);

            // Triangulación del polígono para integrar solo dentro del polígono
            var triangulos = TriangularPolígono(pts);
            double volumen = 0;
            foreach (var tri in triangulos)
                volumen += VolumenPrismaTriangular(tri.a, tri.b, tri.c, coef);

            decimal costo = (decimal)Math.Abs(volumen) * material.CostoMetroCubico;

            return new ResultadoCalculo(areaReal, Math.Abs(volumen), costo,
                "Mínimos Cuadrados + Integral Doble");
        }

        // ── MÉTODO 2: Triangulación TIN — polígono de 3-5 puntos ─────────
        // Divide el polígono en triángulos y calcula el volumen de cada prisma
        private ResultadoCalculo CalcularConTIN(Terreno terreno, Material material)
        {
            var pts = terreno.Coordenadas;
            double area = CalcularAreaShoelace(pts);

            var triangulos = TriangularPolígono(pts);
            double volumen = 0;
            foreach (var tri in triangulos)
                volumen += VolumenPrismaTriangularSimple(tri.a, tri.b, tri.c);

            decimal costo = (decimal)Math.Abs(volumen) * material.CostoMetroCubico;

            return new ResultadoCalculo(area, Math.Abs(volumen), costo,
                "Triangulación TIN (Fan)");
        }

        // ── Triangulación Fan desde el centroide ──────────────────────────
        // Divide el polígono convexo (o casi convexo) en triángulos
        // desde el primer punto hacia todos los demás pares consecutivos
        private static List<(Coordenada a, Coordenada b, Coordenada c)> TriangularPolígono(
            List<Coordenada> pts)
        {
            var tris = new List<(Coordenada, Coordenada, Coordenada)>();
            // Fan triangulation desde pts[0]
            for (int i = 1; i < pts.Count - 1; i++)
                tris.Add((pts[0], pts[i], pts[i + 1]));
            return tris;
        }

        // Volumen del prisma triangular usando la fórmula:
        // V = (1/2) * |base triangular en XY| * (z_promedio del triángulo)
        // donde z se evalúa desde el modelo cuadrático
        private static double VolumenPrismaTriangular(
            Coordenada a, Coordenada b, Coordenada c, double[] coef)
        {
            // Área del triángulo en 2D (XY)
            double areaT = Math.Abs(
                (b.X - a.X) * (c.Y - a.Y) -
                (c.X - a.X) * (b.Y - a.Y)) / 2.0;

            // Z evaluado en el centroide del triángulo
            double cx = (a.X + b.X + c.X) / 3.0;
            double cy = (a.Y + b.Y + c.Y) / 3.0;
            double z = EvaluarModelo(coef, cx, cy);

            return areaT * z;
        }

        // Volumen del prisma triangular usando alturas medidas directamente
        // V = (1/6) * |base 2D| * (z_a + z_b + z_c)
        private static double VolumenPrismaTriangularSimple(
            Coordenada a, Coordenada b, Coordenada c)
        {
            double areaT = Math.Abs(
                (b.X - a.X) * (c.Y - a.Y) -
                (c.X - a.X) * (b.Y - a.Y)) / 2.0;

            double zProm = (a.Z + b.Z + c.Z) / 3.0;
            return areaT * zProm;
        }

        // ── Ajuste por Mínimos Cuadrados ──────────────────────────────────
        // z = ax² + by² + cxy + dx + ey + f
        public static double[] AjustarMinCuadrados(List<Coordenada> pts)
        {
            int n = pts.Count;
            int m = 6;

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

            double[,] AtA = MultiplicarMatrices(Transponer(A, n, m), m, n, A, n, m);
            double[] Atb = MultiplicarMatrizVector(Transponer(A, n, m), m, n, b);

            return GaussJordan(AtA, Atb, m);
        }

        public static double EvaluarModelo(double[] c, double x, double y) =>
            c[0] * x * x + c[1] * y * y + c[2] * x * y + c[3] * x + c[4] * y + c[5];

        // ── Shoelace — área real del polígono ─────────────────────────────
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

        // ── Álgebra lineal ────────────────────────────────────────────────
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
