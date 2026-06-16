using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Services;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Controller
{
    internal class CtlCambioContraseña
    {
        public CambioContraseña Vista { get; set; }

        private readonly IAuthService _auth;
        private readonly IHashService _hash;
        private readonly Usuario _usuarioActual;

        public CtlCambioContraseña(IAuthService auth, IHashService hash,
                                   Usuario usuarioActual, CambioContraseña vista)
        {
            _auth = auth;
            _hash = hash;
            _usuarioActual = usuarioActual;
            Vista = vista;

            Vista.btnCambiarContraseña.Click += (s, e) => CambiarPassword();
        }

        private void CambiarPassword()
        {
            string actual = Vista.GetContraseñaActual();
            string nueva = Vista.GetContraseñaNueva();
            string confirmar = Vista.GetContraseñaConfirmar();

            if (string.IsNullOrWhiteSpace(actual) ||
                string.IsNullOrWhiteSpace(nueva) ||
                string.IsNullOrWhiteSpace(confirmar))
            {
                Vista.MostrarMensaje("Todos los campos son obligatorios.", esError: true);
                return;
            }

            if (!_hash.Verify(actual, _usuarioActual.PasswordHash))
            {
                Vista.MostrarMensaje("La contraseña actual es incorrecta.", esError: true);
                return;
            }

            if (nueva != confirmar)
            {
                Vista.MostrarMensaje("La nueva contraseña y la confirmación no coinciden.", esError: true);
                return;
            }

            if (_hash.Verify(nueva, _usuarioActual.PasswordHash))
            {
                Vista.MostrarMensaje("La nueva contraseña no puede ser igual a la actual.", esError: true);
                return;
            }

            try
            {
                AuthService.ValidarPassword(nueva);
            }
            catch (System.ArgumentException ex)
            {
                Vista.MostrarMensaje(ex.Message, esError: true);
                return;
            }

            try
            {
                _auth.CambiarPassword(_usuarioActual, nueva);
                Vista.MostrarMensaje("Contraseña cambiada correctamente.");
                Vista.LimpiarFormulario();
            }
            catch (System.Exception ex)
            {
                Vista.MostrarMensaje(ex.Message, esError: true);
            }
        }
    }
}
