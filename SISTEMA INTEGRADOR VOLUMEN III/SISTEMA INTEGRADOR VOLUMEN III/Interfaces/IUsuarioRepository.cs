using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces
{
    internal interface IUsuarioRepository
    {
        bool ValidarUsuario(string usuario, string password);

        void GuardarUsuario(string usuario,string password);

        void ActualizarPassword(string usuario, string nuevaPassword);
    }
}
