using SISTEMA_INTEGRADOR_VOLUMEN_III;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Services;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Controller
{
    internal class CtlUsuario
    {
        public Login? VistaLogin { get; set; }
        public RegistroAdmin? VistaRegistro { get; set; }

        private DataManager<Usuario> dataManager;
        private List<Usuario> usuarios;
        private readonly IAuthService authService;

        public Usuario? UsuarioAutenticado { get; private set; }

        public CtlUsuario(DataManager<Usuario> dataManager, IAuthService authService)
        {
            this.dataManager = dataManager;
            this.authService = authService;
            usuarios = dataManager.GetAll();

            // ── Decisión: ¿hay algún administrador registrado? ───────────
            bool hayAdmin = usuarios.Any(u => u.Rol == Rol.Administrador);

            if (!hayAdmin)
                AbrirRegistroAdmin();
            else
                AbrirLogin();
        }

        // ── FLUJO 1: Primer uso — registrar administrador ────────────────
        private void AbrirRegistroAdmin()
        {
            VistaRegistro = new RegistroAdmin();

            VistaRegistro.btnRegistarAdmin.Click += (sender, e) =>
            {
                RegistrarAdmin();
            };

            //Application.Run(VistaRegistro);
            VistaRegistro.ShowDialog();
        }

        private void RegistrarAdmin()
        {
            string[] line = VistaRegistro!.GetInput();

            // 1. Validar contraseñas (ahora son los índices 6 y 7)
            if (line[6] != line[7])
            {
                VistaRegistro.MostrarError("Las contraseñas no coinciden");
                return;
            }

            try
            {
                // 2. Mapear los 10 campos del Usuario
                Usuario usuario = new Usuario
                {
                    Id = dataManager.GetNextId(),
                    Nombre = line[0],             // Nombre Completo
                    Documento = line[1],          // Documento
                    CorreoElectronico = line[2],  // Correo Electronico
                    Telefono = line[3],           // Telefono
                    Direccion = line[4],          // Dirección
                    Username = line[5],           // Usuario
                    Rol = Rol.Administrador,
                    Estado = EstadoUsuario.Activo
                };

                // 3. Registrar usando la contraseña (índice 6)
                authService.Registrar(usuario, line[6]);

                usuarios = dataManager.GetAll();

                VistaRegistro.Hide();

                MessageBox.Show(
                    "Administrador registrado.\nAhora puede iniciar sesión.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                VistaRegistro.Close();
                AbrirLogin();
            }
            catch (Exception ex)
            {
                VistaRegistro.MostrarError(ex.Message);
            }
        }

        // ── FLUJO 2: Login normal ────────────────────────────────────────
        private void AbrirLogin()
        {
            VistaLogin = new Login();

            VistaLogin.btnIngresarSesion.Click += (sender, e) =>
            {
                Autenticar();
            };
            
            VistaLogin.chkMostrar.CheckedChanged += (sender, e) =>
            {
                VistaLogin.txtContraseña.PasswordChar = VistaLogin.chkMostrar.Checked ? '\0' : '●';
            };

            //Application.Run(VistaLogin);
            VistaLogin.ShowDialog();
        }

        private void Autenticar()
        {
            string[] line = VistaLogin!.GetInput();
            // line[0]=Username, line[1]=Password

            if (string.IsNullOrWhiteSpace(line[0]) || string.IsNullOrWhiteSpace(line[1]))
            {
                VistaLogin.MostrarError("Debe ingresar usuario y contraseña.");
                return;
            }

            try
            {
                Usuario? usuario = authService.Login(line[0], line[1]);

                if (usuario == null)
                {
                    VistaLogin.MostrarError("Usuario o contraseña incorrectos.");
                    VistaLogin.LimpiarPassword();
                    return;
                }

                UsuarioAutenticado = usuario;
                VistaLogin.Close();    // Program.cs abre el menú principal
            }
            catch (InvalidOperationException ex) when (ex.Message == "INACTIVO")
            {
                VistaLogin.MostrarError("Su cuenta está inactiva. Contacte al administrador.");
            }
            catch (Exception ex)
            {
                VistaLogin.MostrarError($"Error: {ex.Message}");
            }
        }

        // ── Operaciones CRUD (las usan los demás controladores) ──────────
        public List<Usuario> Listar()
        {
            usuarios = dataManager.GetAll();
            return usuarios;
        }

        public void Add(Usuario usuario, string password)
        {
            authService.Registrar(usuario, password);
            usuarios = dataManager.GetAll();
        }

        public void Actualizar(Usuario usuarioEditado)
        {
            int idx = usuarios.FindIndex(u => u.Id == usuarioEditado.Id);
            if (idx < 0) throw new InvalidOperationException("Usuario no encontrado.");
            usuarioEditado.PasswordHash = usuarios[idx].PasswordHash; // preservar hash
            usuarios[idx] = usuarioEditado;
            Save();
        }

        public void ToggleEstado(int id)
        {
            var u = usuarios.FirstOrDefault(x => x.Id == id)
                ?? throw new InvalidOperationException("Usuario no encontrado.");
            u.Estado = u.Estado == EstadoUsuario.Activo
                ? EstadoUsuario.Inactivo
                : EstadoUsuario.Activo;
            Save();
        }

        private void Save()
        {
            dataManager.Save(usuarios);
        }
    }
}
