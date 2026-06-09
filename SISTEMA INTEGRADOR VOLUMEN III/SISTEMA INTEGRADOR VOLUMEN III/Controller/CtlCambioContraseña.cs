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

            // 1. Campos vacíos
            if (string.IsNullOrWhiteSpace(actual) ||
                string.IsNullOrWhiteSpace(nueva) ||
                string.IsNullOrWhiteSpace(confirmar))
            {
                Vista.MostrarMensaje("Todos los campos son obligatorios.", esError: true);
                return;
            }

            // 2. Contraseña actual correcta
            if (!_hash.Verify(actual, _usuarioActual.PasswordHash))
            {
                Vista.MostrarMensaje("La contraseña actual es incorrecta.", esError: true);
                return;
            }

            // 3. Nueva y confirmación coinciden
            if (nueva != confirmar)
            {
                Vista.MostrarMensaje("La nueva contraseña y la confirmación no coinciden.", esError: true);
                return;
            }

            // 4. Nueva no puede ser igual a la actual
            if (_hash.Verify(nueva, _usuarioActual.PasswordHash))
            {
                Vista.MostrarMensaje("La nueva contraseña no puede ser igual a la actual.", esError: true);
                return;
            }

            // 5. Validar requisitos (longitud, mayúscula, número, especial)
            try
            {
                AuthService.ValidarPassword(nueva);
            }
            catch (System.ArgumentException ex)
            {
                Vista.MostrarMensaje(ex.Message, esError: true);
                return;
            }

            // 6. Persistir
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
