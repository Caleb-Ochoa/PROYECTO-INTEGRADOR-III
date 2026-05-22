using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Usuario : Persona
    {
        public Usuario()
        {

        }

        public Usuario(
            int id,
            string nombre,
            string documento,
            string correoElectronico,
            string telefono,
            string direccion,
            string usuario,
            string passwordHash)
            : base(
                  id,
                  nombre,
                  documento,
                  correoElectronico,
                  telefono,
                  direccion,
                  usuario,
                  passwordHash)
        {

        }
    }
}
