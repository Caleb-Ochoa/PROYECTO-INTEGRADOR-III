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
        public GestionUsuario? VistaGestion { get; set; }
        private DataManager<Usuario> dataManager;
        private List<Usuario> usuarios;
        private readonly IAuthService authService;

        public Usuario? UsuarioAutenticado { get; private set; }

        public CtlUsuario(DataManager<Usuario> dataManager, IAuthService authService,
                bool iniciarFlujoLogin = true)
        {
            this.dataManager = dataManager;
            this.authService = authService;


            usuarios = dataManager.GetAll();


            if (iniciarFlujoLogin)
            {
                bool hayAdmin = usuarios.Any(u => u.Rol == Rol.Administrador);

                if (!hayAdmin)
                    AbrirRegistroAdmin();
                else
                    AbrirLogin();
            }
        }
        public CtlUsuario(DataManager<Usuario> dataManager, IAuthService authService, GestionUsuario vistaGestion)
        {
            this.dataManager = dataManager;
            this.authService = authService;
            VistaGestion = vistaGestion;

            usuarios = dataManager.GetAll();
            ConfigurarVistaGestion();
        }

        private void ConfigurarVistaGestion()
        {
            if (VistaGestion == null)
                return;

            CargarGrid();

            // Botón Agregar
            VistaGestion.btnAgregarUsuarios.Click += (s, e) =>
            {
                AgregarUsuario();
            };

            // Buscar en tiempo real
            VistaGestion.textBox1.TextChanged += (s, e) =>
            {
                BuscarUsuario();
            };

            // Limpiar filtro
            VistaGestion.btnLimpiarGestionUsuarios.Click += (s, e) =>
            {
                VistaGestion.textBox1.Clear();
                CargarGrid();
            };

            // Buscar con botón
            VistaGestion.btnBuscar.Click += (s, e) =>
            {
                BuscarUsuario();
            };

            // Click en columna Editar del grid
            VistaGestion.dgvUsuarios.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                string colName = VistaGestion.dgvUsuarios.Columns[e.ColumnIndex].Name;
                var celda = VistaGestion.dgvUsuarios.Rows[e.RowIndex].Cells["Id"];
                if (celda?.Value == null) return;

                int id = (int)celda.Value;

                if (colName == "Acciones")
                    EditarUsuario(id);
                else if (colName == "ResetPass")
                    RestablecerPassword(id);
            };
        }

        private void RestablecerPassword(int id)
        {
            if (VistaGestion == null) return;

            Usuario? u = usuarios.FirstOrDefault(x => x.Id == id);
            if (u == null) return;

            string? nuevaPassword = VistaGestion.MostrarPopupRestablecerPassword(u.Nombre);
            if (nuevaPassword == null) return;

            try
            {
                authService.RestablecerPassword(u, nuevaPassword);
                MessageBox.Show($"Contraseña de {u.Nombre} restablecida correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarGrid()
        {
            if (VistaGestion == null)
                return;

            usuarios = dataManager.GetAll();

            VistaGestion.dgvUsuarios.DataSource = null;
            VistaGestion.dgvUsuarios.DataSource =
                usuarios.Select(u => new
                {
                    u.Id,
                    u.Nombre,
                    u.Documento,
                    Correo = u.CorreoElectronico,
                    u.Telefono,
                    u.Username,
                    Rol = u.Rol.ToString(),
                    Estado = u.Estado.ToString()
                }).ToList();

            EstilizarGrid();
            AgregarColumnaEditar();
        }

        private void EstilizarGrid()
        {
            if (VistaGestion == null) return;
            VistaGestion.dgvUsuarios.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            VistaGestion.dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(240, 240, 240);
            VistaGestion.dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            VistaGestion.dgvUsuarios.EnableHeadersVisualStyles = false;
            VistaGestion.dgvUsuarios.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);
            VistaGestion.dgvUsuarios.RowTemplate.Height = 32;
            VistaGestion.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
        }

        private void AgregarColumnaEditar()
        {
            if (VistaGestion == null) return;

            if (VistaGestion.dgvUsuarios.Columns.Contains("Acciones"))
                VistaGestion.dgvUsuarios.Columns.Remove("Acciones");

            if (VistaGestion.dgvUsuarios.Columns.Contains("ResetPass"))
                VistaGestion.dgvUsuarios.Columns.Remove("ResetPass");

            // Botón Editar — verde
            VistaGestion.dgvUsuarios.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Acciones",
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 80,
                DefaultCellStyle =
        {
            BackColor = Color.FromArgb(16, 185, 129),
            ForeColor = Color.White,
            Font      = new Font("Segoe UI", 9F, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });

            // Botón Restablecer — rojo
            VistaGestion.dgvUsuarios.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "ResetPass",
                HeaderText = "Contraseña",
                Text = "Restablecer",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 110,
                DefaultCellStyle =
        {
            BackColor = Color.FromArgb(220, 38, 38),
            ForeColor = Color.White,
            Font      = new Font("Segoe UI", 9F, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
            });
        }

        private void BuscarUsuario()
        {
            if (VistaGestion == null) return;

            string termino = VistaGestion.textBox1.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termino)) { CargarGrid(); return; }

            VistaGestion.dgvUsuarios.DataSource = null;
            VistaGestion.dgvUsuarios.DataSource = usuarios
                .Where(u => u.Nombre.ToLower().Contains(termino) ||
                            u.Username.ToLower().Contains(termino) ||
                            u.Documento.ToLower().Contains(termino))
                .Select(u => new
                {
                    u.Id,
                    u.Nombre,
                    u.Documento,
                    Correo = u.CorreoElectronico,
                    u.Telefono,
                    u.Username,
                    Rol = u.Rol.ToString(),
                    Estado = u.Estado.ToString()
                }).ToList();

            EstilizarGrid();
            AgregarColumnaEditar();
        }

        private void EditarUsuario(int id)
        {
            if (VistaGestion == null) return;

            Usuario? u = usuarios.FirstOrDefault(x => x.Id == id);
            if (u == null) return;

            string[]? datos = VistaGestion.MostrarPopupEditar(
                u.Nombre, u.Documento, u.Telefono,
                u.CorreoElectronico, u.Direccion,
                u.Username, u.Rol.ToString());

            if (datos == null) return;

            try
            {
                // [0]Nombre [1]Documento [2]Telefono [3]Correo [4]Direccion [5]Username [6]Rol
                u.Nombre = datos[0];
                u.Documento = datos[1];
                u.Telefono = datos[2];
                u.CorreoElectronico = datos[3];
                u.Direccion = datos[4];
                u.Username = datos[5];
                u.Rol = datos[6] == "Administrador"
                    ? Rol.Administrador : Rol.Usuario;

                Save();
                usuarios = dataManager.GetAll();
                CargarGrid();

                MessageBox.Show("Usuario actualizado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarUsuario()
        {
            if (VistaGestion == null)
                return;

            string[]? datos = VistaGestion.MostrarPopupAgregar();

            if (datos == null)
                return;

            try
            {
                Usuario usuario = new Usuario
                {
                    Id = dataManager.GetNextId(),
                    Nombre = datos[0],
                    Documento = datos[1],
                    Telefono = datos[2],
                    CorreoElectronico = datos[3],
                    Direccion = datos[4],
                    Username = datos[5],
                    Rol = datos[7] == "Administrador"
                        ? Rol.Administrador
                        : Rol.Usuario,
                    Estado = EstadoUsuario.Activo
                };

                Add(usuario, datos[6]);

                usuarios = dataManager.GetAll();

                CargarGrid();

                MessageBox.Show(
                    "Usuario agregado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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

            VistaLogin.txtContraseña.UseSystemPasswordChar = true;

            VistaLogin.chkMostrar.CheckedChanged += (sender, e) =>
            {
                VistaLogin.txtContraseña.UseSystemPasswordChar = !VistaLogin.chkMostrar.Checked;
            };

            VistaLogin.btnIngresarSesion.Click += (sender, e) =>
            {
                Autenticar();
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
