using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Terreno
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public List<Coordenada> Coordenadas { get; set; }

        public double Area { get; set; }

        public double Volumen { get; set; }

        public Terreno(string nombre, double area, double volumen)
        {
            Id = Guid.NewGuid();

            Nombre = nombre;

            Area = area;

            Volumen = volumen;

            Coordenadas = new List<Coordenada>();
        }

        // Método para agregar coordenadas
        public void AgregarCoordenada(Coordenada c)
        {
            Coordenadas.Add(c);
        }

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Nombre: {Nombre}\n" +
                   $"Área: {Area}\n" +
                   $"Volumen: {Volumen}\n" +
                   $"Cantidad Coordenadas: {Coordenadas.Count}";
        }
    }
}
