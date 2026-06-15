using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Services
{
    internal class AuthService : IAuthService
    {
        private readonly DataManager<Usuario> _dm;
        private readonly IHashService _hash;

        public AuthService(DataManager<Usuario> dm, IHashService hash)
        { _dm = dm; _hash = hash; }

        // Login 
        public Usuario? Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            Usuario? usuario = _dm.GetAll().FirstOrDefault(u => string.Equals(u.Username, username.Trim(),
                    StringComparison.OrdinalIgnoreCase));

            if (usuario == null) return null;

            if (usuario.Estado == EstadoUsuario.Inactivo)
                throw new InvalidOperationException("INACTIVO");

            return _hash.Verify(password, usuario.PasswordHash) ? usuario : null;
        }

        // Registrar
        public void Registrar(Usuario usuario, string password)
        {
            ValidarCamposObligatorios(usuario);
            ValidarPassword(password);

            List<Usuario> todos = _dm.GetAll();

            if (todos.Any(u => string.Equals(u.Username, usuario.Username.Trim(),
                    StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("El nombre de usuario ya existe.");

            if (todos.Any(u => string.Equals(u.Documento, usuario.Documento.Trim())))
                throw new InvalidOperationException("Ya existe un usuario con ese documento.");

            usuario.Username = usuario.Username.Trim();
            usuario.PasswordHash = _hash.Hash(password);
            usuario.Id = _dm.GetNextId();

            todos.Add(usuario);
            _dm.Save(todos);  
        }

        // Cambiar contraseña (el propio usuario)
        public void CambiarPassword(Usuario usuario, string nuevaPassword)
        {
            ValidarPassword(nuevaPassword);
            List<Usuario> todos = _dm.GetAll();
            Usuario? existente = todos.FirstOrDefault(u => u.Id == usuario.Id);
            if (existente == null)
                throw new InvalidOperationException("Usuario no encontrado.");
            existente.PasswordHash = _hash.Hash(nuevaPassword);
            _dm.Save(todos);
        }

        // Restablecer contraseña (admin)
        public void RestablecerPassword(Usuario usuario, string nuevaPassword)
        {
            ValidarPassword(nuevaPassword);
            List<Usuario> todos = _dm.GetAll();
            Usuario? existente = todos.FirstOrDefault(u => u.Id == usuario.Id);
            if (existente == null)
                throw new InvalidOperationException("Usuario no encontrado.");
            existente.PasswordHash = _hash.Hash(nuevaPassword);
            _dm.Save(todos);
        }

        // Validaciones privadas
        private static void ValidarCamposObligatorios(Usuario u)
        {
            if (string.IsNullOrWhiteSpace(u.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(u.Documento))
                throw new ArgumentException("El documento es obligatorio.");
            if (string.IsNullOrWhiteSpace(u.Username))
                throw new ArgumentException("El nombre de usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(u.CorreoElectronico))
                throw new ArgumentException("El correo es obligatorio.");
            if (!Regex.IsMatch(u.CorreoElectronico, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El correo no tiene un formato válido.");
        }

        public static void ValidarPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña es obligatoria.");
            if (password.Length < 8)
                throw new ArgumentException("La contraseña debe tener mínimo 8 caracteres.");
            if (!password.Any(char.IsUpper))
                throw new ArgumentException("Debe contener al menos una letra mayúscula.");
            if (!password.Any(char.IsDigit))
                throw new ArgumentException("Debe contener al menos un número.");
            if (password.All(c => char.IsLetterOrDigit(c)))
                throw new ArgumentException("Debe contener al menos un carácter especial.");
        }
    }
}
