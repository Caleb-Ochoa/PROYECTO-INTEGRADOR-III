using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces
{
    internal interface IAuthService
    {
        Usuario? Login(string username, string password);
        void Registrar(Usuario usuario, string password);
        void CambiarPassword(Usuario usuario, string nuevaPassword);
        void RestablecerPassword(Usuario usuario, string nuevaPassword);
    }
}
