using System;
using System.Collections.Generic;
using System.Text;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IUsuarioRepository repository;

        private readonly IHashService hashService;

        public AuthService(IUsuarioRepository repository, IHashService hashService)
        {
            this.repository = repository;
            this.hashService = hashService;
        }

        public void ChangePassword(string usuario, string nuevaPassword)
        {
            string passwordHash = hashService.GenerarHash(nuevaPassword);

            repository.ActualizarPassword(
                usuario,
                passwordHash
            );
        }

        public bool Login(string usuario, string password)
        {
            string passwordHash = hashService.GenerarHash(password);

            return repository.ValidarUsuario(
                usuario,
                passwordHash
            );
            
        }

        public void Registrar(string usuario, string password)
        {
            string passwordHash = hashService.GenerarHash(password);

            repository.GuardarUsuario(
                usuario,
                passwordHash
            );
        }
        
    }
}
