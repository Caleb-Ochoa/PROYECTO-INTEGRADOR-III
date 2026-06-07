using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;        

namespace SISTEMA_INTEGRADOR_VOLUMEN_III
{
    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();
            Idioma.Aplicar(this);


        }
        private void Login_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CentrarPanel();

        }
        public string[] GetInput()
        {
            return new string[]
            {
                txtUsuario.Text.Trim(), // line[0] - Reemplaza por el Name real de tu TextBox de Usuario
                txtContraseña.Text        // line[1] - El TextBox de contraseña que pusiste público
            };
        }
        /// Muestra un cuadro de diálogo en caso de datos incorrectos o bloqueos.
        public void RowError(string mensaje) // Nota: En tu CtlUsuario llamaste a "MostrarError"
        {
            MessageBox.Show(mensaje, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Si en tu CtlUsuario escribiste 'VistaLogin.MostrarError', usa este nombre:
        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// Limpia el campo de contraseña si el intento falla.
        public void LimpiarPassword()
        {
            txtContraseña.Clear();
            txtContraseña.Focus();
        }
        private void label3_Click(object sender, EventArgs e)
        {


        }
        private void CentrarPanel()
        {
            pnlLogin.Left = (this.ClientSize.Width - pnlLogin.Width) / 2;
            pnlLogin.Top = (this.ClientSize.Height - pnlLogin.Height) / 2;
        }
        private void Login_Resize(object sender, EventArgs e)
        {
            CentrarPanel();
        }
        private void btnIdioma_Click(object sender, EventArgs e)
        {
            Idioma.MostrarSelector(this);

        }
    }
}
