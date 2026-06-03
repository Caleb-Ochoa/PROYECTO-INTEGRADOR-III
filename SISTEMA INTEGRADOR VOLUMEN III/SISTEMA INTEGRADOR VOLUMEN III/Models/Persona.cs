using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

        protected Persona() { }

        protected Persona(int id, string nombre, string documento,
            string correo, string telefono, string direccion)
        {
            Id = id; Nombre = nombre; Documento = documento;
            CorreoElectronico = correo; Telefono = telefono; Direccion = direccion;
        }

        // Separa con | para evitar conflictos con comas en los datos
        public override string ToString() =>
            $"{Id}|{Nombre}|{Documento}|{CorreoElectronico}|{Telefono}|{Direccion}";
    }
}
