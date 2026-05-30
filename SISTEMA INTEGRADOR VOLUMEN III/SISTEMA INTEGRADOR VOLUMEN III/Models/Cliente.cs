using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Models
{
    internal class Cliente : Persona
    {
        public DateTime FechaRegistro { get; set; }

        public Cliente()
        {
            FechaRegistro = DateTime.Now;
        }

        public Cliente(
            int id,
            string nombre,
            string documento,
            string correoElectronico,
            string telefono,
            string direccion,
            DateTime fechaRegistro)
            : base(
                id,
                nombre,
                documento,
                correoElectronico,
                telefono,
                direccion)
        {
            FechaRegistro = fechaRegistro;
        }
    }
}
