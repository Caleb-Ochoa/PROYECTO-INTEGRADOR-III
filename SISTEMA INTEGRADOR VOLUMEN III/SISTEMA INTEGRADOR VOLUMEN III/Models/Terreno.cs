using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Terreno
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        public string Nombre { get; set; }

        public List<Coordenada> Coordenadas { get; set; }

        public Terreno()
        {
            Nombre = string.Empty;
            Coordenadas = new List<Coordenada>();
        }

        public Terreno(
            int id,
            int clienteId,
            string nombre,
            List<Coordenada> coordenadas)
        {
            Id = id;
            ClienteId = clienteId;
            Nombre = nombre;
            Coordenadas = coordenadas ?? new List<Coordenada>();
        }
    }
}
