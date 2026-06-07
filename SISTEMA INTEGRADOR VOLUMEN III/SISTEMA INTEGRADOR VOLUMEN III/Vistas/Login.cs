using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;        

namespace SISTEMA_INTEGRADOR_VOLUMEN_III
{
    public partial class Login : Form
    {
<<<<<<< HEAD
=======

>>>>>>> fdca2ae56d8d638d4f6edcdd37df99701cbfa571

        public Login()
        {
            InitializeComponent();
            Idioma.Aplicar(this);

<<<<<<< HEAD
        }
        private void Login_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CentrarPanel();
=======
>>>>>>> fdca2ae56d8d638d4f6edcdd37df99701cbfa571
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

<<<<<<< HEAD
        }
        private void CentrarPanel()
        {
            pnlLogin.Left = (this.ClientSize.Width - pnlLogin.Width) / 2;
            pnlLogin.Top = (this.ClientSize.Height - pnlLogin.Height) / 2;
        }
        private void Login_Resize(object sender, EventArgs e)
        {
            CentrarPanel();
=======
        private void btnIdioma_Click(object sender, EventArgs e)
        {
            Idioma.MostrarSelector(this);
>>>>>>> fdca2ae56d8d638d4f6edcdd37df99701cbfa571
        }
    }
}
