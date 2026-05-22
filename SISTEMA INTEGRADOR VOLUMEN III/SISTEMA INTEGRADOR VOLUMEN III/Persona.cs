using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III
{
    internal abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        // Constructor vacío protegido
        // Necesario para serialización/deserialización JSON
        protected Persona()
        {
            Nombre = string.Empty;
            Documento = string.Empty;
            Telefono = string.Empty;
            CorreoElectronico = string.Empty;
        }
        

        // Constructor principal
        protected Persona(
            string nombre,
            string documento,
            string telefono,
            string correo)
        {
            Nombre = nombre;
            Documento = documento;
            Telefono = telefono;
            CorreoElectronico = correo;
        }

        public Persona(int id, string nombre, string correoElectronico, string telefono, string direccion)
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
