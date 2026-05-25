using System;
using System.Collections.Generic;
using System.Text;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Repository
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        public void ActualizarPassword(string usuario, string nuevaPassword)
        {
            
        }

        public void GuardarUsuario(string usuario, string password)
        {
            
        }

        public bool ValidarUsuario(string usuario, string password)
        {
            return true;
        }
    }
}
