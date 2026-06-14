using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Usuario : Persona
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Rol Rol { get; set; }
        public EstadoUsuario Estado { get; set; }

        public Usuario() { }

        public Usuario(int id, string nombre, string documento, string correo,
            string telefono, string direccion, string username,
            string passwordHash, Rol rol, EstadoUsuario estado)
            : base(id, nombre, documento, correo, telefono, direccion)
        {
            Username = username; PasswordHash = passwordHash;
            Rol = rol; Estado = estado;
        }

        public override string ToString() =>
            $"{base.ToString()}|{Username}|{PasswordHash}|{Rol}|{Estado}";

        public static Usuario FromText(string line)
        {
            string[] p = line.Split('|');
            if (p.Length != 10)
                throw new FormatException($"Línea de usuario con formato inválido ({p.Length} campos, se esperan 10): {line}");
            return new Usuario
            {
                Id = int.Parse(p[0]),
                Nombre = p[1],
                Documento = p[2],
                CorreoElectronico = p[3],
                Telefono = p[4],
                Direccion = p[5],
                Username = p[6],
                PasswordHash = p[7],
                Rol = (Rol)Enum.Parse(typeof(Rol), p[8]),
                Estado = (EstadoUsuario)Enum.Parse(typeof(EstadoUsuario), p[9])
            };
        }
    }
}
