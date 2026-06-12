using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    public class Terreno
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<Coordenada> Coordenadas { get; set; } = new();

        public Terreno() { }
        public Terreno(int id, int clienteId, string nombre, List<Coordenada> coords)
        { Id = id; ClienteId = clienteId; Nombre = nombre; Coordenadas = coords ?? new(); }

        // Formato: id|clienteId|nombre|coord1~coord2~coord3...
        public override string ToString()
        {
            string coords = string.Join("~", Coordenadas.Select(c => c.ToString()));
            return $"{Id}|{ClienteId}|{Nombre}|{coords}";
        }

        public static Terreno FromText(string line)
        {
            string[] p = line.Split('|');
            if (p.Length < 4)
                throw new FormatException($"Terreno inválido ({p.Length} campos): {line}");
            var coords = string.IsNullOrWhiteSpace(p[3])
                ? new List<Coordenada>()
                : p[3].Split('~').Select(Coordenada.FromText).ToList();
            return new Terreno
            {
                Id = int.Parse(p[0]),
                ClienteId = int.Parse(p[1]),
                Nombre = p[2],
                Coordenadas = coords
            };
        }
    }
}
