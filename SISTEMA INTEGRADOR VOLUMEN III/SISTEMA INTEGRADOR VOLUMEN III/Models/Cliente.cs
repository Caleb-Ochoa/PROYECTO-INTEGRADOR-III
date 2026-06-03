using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Cliente : Persona
    {
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public Cliente() { }

        public Cliente(int id, string nombre, string documento, string correo,
            string telefono, string direccion, DateTime fechaRegistro)
            : base(id, nombre, documento, correo, telefono, direccion)
        {
            FechaRegistro = fechaRegistro;
        }

        public override string ToString() =>
            $"{base.ToString()}|{FechaRegistro:O}";

        public static Cliente FromText(string line)
        {
            string[] p = line.Split('|');
            if (p.Length != 7)
                throw new FormatException($"Línea de cliente inválida ({p.Length} campos): {line}");
            return new Cliente
            {
                Id = int.Parse(p[0]),
                Nombre = p[1],
                Documento = p[2],
                CorreoElectronico = p[3],
                Telefono = p[4],
                Direccion = p[5],
                FechaRegistro = DateTime.Parse(p[6])
            };
        }
    }
}
