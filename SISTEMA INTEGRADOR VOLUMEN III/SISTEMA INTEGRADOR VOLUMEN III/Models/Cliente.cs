using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

        public Cliente(string nombre, string identificacion,
                   string telefono, string correo,
                   string direccion)
        {
            Id = Guid.NewGuid();

            Nombre = nombre;
            Identificacion = identificacion;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
        }
        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Nombre: {Nombre}\n" +
                   $"Identificación: {Identificacion}\n" +
                   $"Teléfono: {Telefono}\n" +
                   $"Correo: {Correo}\n" +
                   $"Dirección: {Direccion}";
        }
    }
}
