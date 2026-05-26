using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal abstract class Persona
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Documento { get; set; }

        public string CorreoElectronico { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        

        protected Persona()
        {
            Nombre = string.Empty;
            Documento = string.Empty;
            CorreoElectronico = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            //Usuario = string.Empty;
            //PasswordHash = string.Empty;
        }

        // =========================
        // CONSTRUCTOR PRINCIPAL
        // =========================

        public Persona(
            int id,
            string nombre,
            string documento,
            string correoElectronico,
            string telefono,
            string direccion)
            //string usuario,
            //string passwordHash
        {
            Id = id;
            Nombre = nombre;
            Documento = documento;
            CorreoElectronico = correoElectronico;
            Telefono = telefono;
            Direccion = direccion;
            //Usuario = usuario;
            //PasswordHash = passwordHash;
        }

        // =========================
        // TOSTRING
        // =========================

        public override string ToString()
        {
            return
                $"ID: {Id}\n" +
                $"Nombre: {Nombre}\n" +
                $"Documento: {Documento}\n" +
                $"Correo: {CorreoElectronico}\n" +
                $"Telefono: {Telefono}\n" +
                $"Direccion: {Direccion}\n";
                //$"Usuario: {Usuario}";
        }
    }
}
