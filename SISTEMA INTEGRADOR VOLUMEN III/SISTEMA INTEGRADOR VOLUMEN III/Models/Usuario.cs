using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Usuario : Persona
    {
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public Rol Rol { get; set; }

        public EstadoUsuario Estado { get; set; }

        public Usuario()
        {
            Username = string.Empty;
            PasswordHash = string.Empty;
        }

        public Usuario(
            int id,
            string nombre,
            string documento,
            string correoElectronico,
            string telefono,
            string direccion,
            string username,
            string passwordHash,
            Rol rol,
            EstadoUsuario estado)
            : base(
                id,
                nombre,
                documento,
                correoElectronico,
                telefono,
                direccion)
        {
            Username = username;
            PasswordHash = passwordHash;
            Rol = rol;
            Estado = estado;
        }
    }
}
