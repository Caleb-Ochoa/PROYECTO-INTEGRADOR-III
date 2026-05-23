using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Administrador : Usuario
    {
        public Administrador()
        {
        }

        public Administrador(int id, string nombre, string documento, string correo, string telefono, string direccion, string username, string passwordHash, Rol rol, EstadoUsuario estado) : base(id, nombre, documento, correo, telefono, direccion, username, passwordHash, rol, estado)
        {
        }
    }
}
