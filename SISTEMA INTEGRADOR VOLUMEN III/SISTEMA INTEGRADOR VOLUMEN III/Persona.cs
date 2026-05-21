using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III
{
    internal class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public long Documento { get; set; }
        public string CorreoElectronico { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }

        // Constructor vacío protegido
        // Necesario para serialización/deserialización JSON
        protected Persona()
        {
            Nombre = string.Empty;
            Identificacion = string.Empty;
            Telefono = string.Empty;
            Correo = string.Empty;
        }
        public Persona()
        {
        }

        // Constructor principal
        protected Persona(
            string nombre,
            string identificacion,
            string telefono,
            string correo)
        {
            Nombre = nombre;
            Identificacion = identificacion;
            Telefono = telefono;
            Correo = correo;
        }

        public Persona(int id, string nombre, string correoElectronico, long telefono, string direccion)
        {
            Id = id;
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Telefono = telefono;
            Direccion = direccion;
        }
        public override string ToString()
        {
            return $"{Id},{Nombre},{CorreoElectronico},{Telefono},{Direccion}";
        }
    }
}
