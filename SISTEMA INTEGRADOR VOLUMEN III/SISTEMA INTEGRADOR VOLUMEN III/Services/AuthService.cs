using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Services
{
    internal class AuthService : IAuthService
    {
        private readonly DataManager<Usuario> dataManager;

        private readonly IHashService hashService;

        public AuthService(DataManager<Usuario> dataManager, IHashService hashService)
        {
            this.dataManager = dataManager;
            this.hashService = hashService;
        }
        public Usuario? Login(string username, string password)
        {
            Usuario? usuario = dataManager.GetByUsername(username);

            if (usuario == null)
            {
                return null;
            }

            if (usuario.Estado ==EstadoUsuario.Inactivo)
            {
                throw new Exception("El usuario está inactivo.");
            }

            bool passwordCorrecta = hashService.Verify(password,usuario.PasswordHash);

            if (!passwordCorrecta)
            {
                return null;
            }

            return usuario;
        }

        public void Registrar(Usuario usuario, string password)
        {
            ValidarUsuario(usuario);

            ValidarPassword(password);

            Usuario? existente = usuarioRepository.GetByUsername(usuario.Username);

            if (existente != null)
            {
                throw new Exception("El nombre de usuario ya existe.");
            }

            usuario.PasswordHash = hashService.Hash(password);

            //usuarioRepository.Add(usuario);
        }

        private void ValidarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new Exception("El nombre es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Documento))
            {
                throw new Exception("El documento es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace( usuario.Username))
            {
                throw new Exception( "El username es obligatorio.");
            }
        }

        private void ValidarPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("La contraseña es obligatoria.");
            }

            if (password.Length < 8)
            {
                throw new Exception( "La contraseña debe tener mínimo 8 caracteres.");
            }

            if (!password.Any(char.IsUpper))
            {
                throw new Exception("La contraseña debe contener al menos una mayúscula.");
            }

            if (!password.Any(char.IsDigit))
            {
                throw new Exception("La contraseña debe contener al menos un número.");
            }

            if (!password.Any( c => !char.IsLetterOrDigit(c)))
            {
                throw new Exception("La contraseña debe contener al menos un carácter especial.");
            }
        }
    }
}
