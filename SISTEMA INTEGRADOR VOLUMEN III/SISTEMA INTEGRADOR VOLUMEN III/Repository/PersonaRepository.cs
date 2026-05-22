using Newtonsoft.Json;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Repository
{
    internal class PersonaRepository : IPersonaRepository
    {
        private readonly string rutaArchivo = "usuarios.json";

        private List<Usuario> personas;

        public PersonaRepository()
        {
            personas = CargarUsuarios();
        }

        // =========================
        // AGREGAR
        // =========================

        public void Agregar(Persona persona)
        {
            personas.Add((Usuario)persona);

            GuardarUsuarios();
        }

        // =========================
        // BUSCAR USUARIO
        // =========================

        public Persona BuscarUsuario(string usuario)
        {
            return personas.FirstOrDefault(p => p.Usuario == usuario);
        }

        // =========================
        // GUARDAR JSON
        // =========================

        private void GuardarUsuarios()
        {
            string json = JsonConvert.SerializeObject(
                personas,
                Formatting.Indented);

            File.WriteAllText(rutaArchivo, json);
        }

        // =========================
        // CARGAR JSON
        // =========================

        private List<Usuario> CargarUsuarios()
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<Usuario>();
            }

            string json = File.ReadAllText(rutaArchivo);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Usuario>();
            }

            return JsonConvert.DeserializeObject<List<Usuario>>(json)
                   ?? new List<Usuario>();
        }
    }
}
