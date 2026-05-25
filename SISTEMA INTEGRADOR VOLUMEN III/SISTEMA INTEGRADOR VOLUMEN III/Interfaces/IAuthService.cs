using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces
{
    internal interface IAuthService
    {
        bool Login(string usuario, string password);

        void Registrar(string usuario, string password);
        void ChangePassword(string usuario, string nuevaPassword);
    }
}
