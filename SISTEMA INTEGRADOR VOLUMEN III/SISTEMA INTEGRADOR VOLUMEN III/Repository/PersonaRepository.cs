using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Repository
{
    internal class PersonaRepository : IPersonaRepository
    {
        private List<Persona> personas;

        public PersonaRepository()
        {
            personas = new List<Persona>();
        }

        public void Agregar(Persona persona)
        {
            personas.Add(persona);
        }

        public Persona BuscarUsuario(string usuario)
        {
            return personas.FirstOrDefault(p => p.Usuario == usuario);
        }
    }
}
