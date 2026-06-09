using SISTEMA_INTEGRADOR_VOLUMEN_III.Controller;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Enums;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Services;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    internal partial class  MenuPrincipal : Form
    {
        private readonly Usuario _usuario;
        private AuthService authService;

        public MenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            Idioma.Aplicar(this);
            _usuario = usuario;
   
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (_usuario.Rol == Rol.Administrador)
            {
                lblAvatar.Text = "👑";
                lblRol.Text = "Administrador";
            }
            else
            {
                lblAvatar.Text = "👤";
                lblRol.Text = "Usuario";
            }

            lblNombre.Text = $"Bienvenido, {_usuario.Nombre}";
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            // Ocultar botones admin si es usuario normal
            btnGUsuarios.Visible = _usuario.Rol == Rol.Administrador;
            btnCambiarContraseña.Visible = _usuario.Rol == Rol.Administrador;

            this.WindowState = FormWindowState.Maximized;
        }
        public void AbrirFormulario(Form formulario)
        {
            if (pnlContenido.Controls.Count > 0) pnlContenido.Controls[0].Dispose();

            formulario.TopLevel = false;  // que no abra como ventana nueva
            formulario.FormBorderStyle = FormBorderStyle.None; // sin bordes
            formulario.Dock = DockStyle.Fill; // ocupa todo el panel

            pnlContenido.Controls.Add(formulario);
            pnlContenido.Tag = formulario;
            formulario.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Este es tu botón de "Cambiar Contraseña" según tu Designer.
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //lblRol.Text = usuario.Rol == Rol.Administrador ? "👑 Administrador" : "👤 Usuario";
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {

            Clientes vista = new Clientes();

            IRepository<Cliente> repo = new RepositorioFile<Cliente>("clientes.txt", Cliente.FromText);

            DataManager<Cliente> dm = new DataManager<Cliente>(repo);

            CtlCliente controlador = new CtlCliente(dm, vista);

            AbrirFormulario(vista);

        }

        private void btnMateriales_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Materiales());
        }

        private void btnTerreno_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Terreno_y_Calculo());
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Cotizaciones());
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Facturas());
        }

        private void btnGUsuario_Click(object sender, EventArgs e)
        {
            GestionUsuario vista = new GestionUsuario();

            IRepository<Usuario> repo =new RepositorioFile<Usuario>("usuarios.txt", Usuario.FromText);

            DataManager<Usuario> dm =new DataManager<Usuario>(repo);

            IHashService hashService =new HashService();

            IAuthService authService =new AuthService(dm, hashService);

            CtlUsuario controlador = new CtlUsuario(dm, authService, vista);

            AbrirFormulario(vista);
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new CambioContraseña());
        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //Login login = new Login();
            //login.Show();
            //this.Close();

            this.Hide();

            // Recrear el flujo completo de autenticación
            IRepository<Usuario> repoUsuario = new RepositorioFile<Usuario>("usuarios.txt", Usuario.FromText);
            DataManager<Usuario> dataManager = new DataManager<Usuario>(repoUsuario);
            IHashService hashService = new HashService();
            IAuthService authService = new AuthService(dataManager, hashService);

            CtlUsuario ctlUsuario = new CtlUsuario(dataManager, authService);

            if (ctlUsuario.UsuarioAutenticado != null)
            {
                // Login exitoso: abrir un nuevo menú con el nuevo usuario
                MenuPrincipal nuevoMenu = new MenuPrincipal(ctlUsuario.UsuarioAutenticado);
                nuevoMenu.Show();
            }

            // Cerrar este menú (ya sea que haya nuevo login o el usuario canceló)
            this.Close();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            Idioma.MostrarSelector(this);
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
