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
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas
{
    internal partial class MenuPrincipal : Form
    {
        private readonly Usuario _usuario;

        public bool CerroSesion { get; private set; } = false;

        public MenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            Idioma.Aplicar(this);
            _usuario = usuario;
        }

        // ── Un solo Load, con el nombre correcto ──────────────────────────
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // Rol e ícono
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

            // Fecha en español sin importar la configuración del PC
            lblFecha.Text = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy",
                new CultureInfo("es-CO"));

            // Botones exclusivos del admin
            btnGUsuarios.Visible = _usuario.Rol == Rol.Administrador;
            btnCambiarContraseña.Visible = true;

            this.WindowState = FormWindowState.Maximized;

        }

        // ── Abrir módulos en el panel derecho ─────────────────────────────
        public void AbrirFormulario(Form formulario)
        {
            splitContainer1.Panel2.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            splitContainer1.Panel2.Controls.Add(formulario);
            formulario.Show();
        }

        // ── Clientes ──────────────────────────────────────────────────────
        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes vista = new Clientes();
            IRepository<Cliente> repo = new RepositorioFile<Cliente>("clientes.txt", Cliente.FromText);
            DataManager<Cliente> dm = new DataManager<Cliente>(repo);
            CtlCliente controlador = new CtlCliente(dm, vista);
            AbrirFormulario(vista);
        }

        // ── Materiales ────────────────────────────────────────────────────
        private void btnMateriales_Click(object sender, EventArgs e)
        {
            Materiales vista = new Materiales();
            IRepository<Material> repo = new RepositorioFile<Material>("materiales.txt", Material.FromText);
            DataManager<Material> dm = new DataManager<Material>(repo);
            CtlMaterial controlador = new CtlMaterial(dm, vista);
            AbrirFormulario(vista);
        }

        // ── Terreno ───────────────────────────────────────────────────────
        private void btnTerreno_Click(object sender, EventArgs e)
        {
            Terreno_y_Calculo vista = new Terreno_y_Calculo();

            IRepository<Terreno> repoT = new RepositorioFile<Terreno>("terrenos.txt", Terreno.FromText);
            IRepository<Cliente> repoC = new RepositorioFile<Cliente>("clientes.txt", Cliente.FromText);
            IRepository<Material> repoM = new RepositorioFile<Material>("materiales.txt", Material.FromText);

            DataManager<Terreno> dmT = new DataManager<Terreno>(repoT);
            DataManager<Cliente> dmC = new DataManager<Cliente>(repoC);
            DataManager<Material> dmM = new DataManager<Material>(repoM);

            ICalculoService calculo = new CalculoService();

            CtlTerreno controlador = new CtlTerreno(dmT, dmC, dmM, calculo, vista);
            AbrirFormulario(vista);
        }

        // ── Cotizaciones ──────────────────────────────────────────────────
        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            Cotizaciones vista = new Cotizaciones();

            IRepository<Cotizacion> repoCot = new RepositorioFile<Cotizacion>("cotizaciones.txt", Cotizacion.FromText);
            IRepository<Cliente> repoCli = new RepositorioFile<Cliente>("clientes.txt", Cliente.FromText);
            IRepository<Terreno> repoTer = new RepositorioFile<Terreno>("terrenos.txt", Terreno.FromText);
            IRepository<Material> repoMat = new RepositorioFile<Material>("materiales.txt", Material.FromText);
            IRepository<Factura> repoFac = new RepositorioFile<Factura>("facturas.txt", Factura.FromText);

            DataManager<Cotizacion> dmCot = new DataManager<Cotizacion>(repoCot);
            DataManager<Cliente> dmCli = new DataManager<Cliente>(repoCli);
            DataManager<Terreno> dmTer = new DataManager<Terreno>(repoTer);
            DataManager<Material> dmMat = new DataManager<Material>(repoMat);
            DataManager<Factura> dmFac = new DataManager<Factura>(repoFac);

            ICalculoService calculo = new CalculoService();
            var codigoGen = new CodigoFiscalGenerator(dmFac);

            CtlCotizacion controlador = new CtlCotizacion(dmCot, dmCli, dmTer, dmMat, dmFac, calculo, codigoGen, vista);
            AbrirFormulario(vista);
        }

        // ── Facturas ──────────────────────────────────────────────────────
        private void btnFactura_Click(object sender, EventArgs e)
        {
            Facturas vista = new Facturas();

            IRepository<Factura> repoFac = new RepositorioFile<Factura>("facturas.txt", Factura.FromText);
            IRepository<Cotizacion> repoCot = new RepositorioFile<Cotizacion>("cotizaciones.txt", Cotizacion.FromText);
            IRepository<Cliente> repoCli = new RepositorioFile<Cliente>("clientes.txt", Cliente.FromText);
            IRepository<Terreno> repoTer = new RepositorioFile<Terreno>("terrenos.txt", Terreno.FromText);
            IRepository<Material> repoMat = new RepositorioFile<Material>("materiales.txt", Material.FromText);

            DataManager<Factura> dmFac = new DataManager<Factura>(repoFac);
            DataManager<Cotizacion> dmCot = new DataManager<Cotizacion>(repoCot);
            DataManager<Cliente> dmCli = new DataManager<Cliente>(repoCli);
            DataManager<Terreno> dmTer = new DataManager<Terreno>(repoTer);
            DataManager<Material> dmMat = new DataManager<Material>(repoMat);

            CtlFactura controlador = new CtlFactura(dmFac, dmCot, dmCli, dmTer, dmMat, vista);
            AbrirFormulario(vista);
        }

        // ── Gestión de usuarios (solo admin) ──────────────────────────────
        private void btnGUsuario_Click(object sender, EventArgs e)
        {
            GestionUsuario vista = new GestionUsuario();
            IRepository<Usuario> repo = new RepositorioFile<Usuario>("usuarios.txt", Usuario.FromText);
            DataManager<Usuario> dm = new DataManager<Usuario>(repo);
            IHashService hashService = new HashService();
            IAuthService authService = new AuthService(dm, hashService);
            CtlUsuario controlador = new CtlUsuario(dm, authService, vista);
            AbrirFormulario(vista);
        }

        // ── Cambiar contraseña (solo admin) ───────────────────────────────
        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            CambioContraseña vista = new CambioContraseña();
            IRepository<Usuario> repo = new RepositorioFile<Usuario>("usuarios.txt", Usuario.FromText);
            DataManager<Usuario> dm = new DataManager<Usuario>(repo);
            IHashService hash = new HashService();
            IAuthService auth = new AuthService(dm, hash);
            CtlCambioContraseña ctrl = new CtlCambioContraseña(auth, hash, _usuario, vista);
            AbrirFormulario(vista);
        }

        // ── Cerrar sesión ─────────────────────────────────────────────────
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerroSesion = true;
            this.Close();
        }

        // ── Configuración de idioma ───────────────────────────────────────
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            Idioma.MostrarSelector(this);
        }  
    }
}
