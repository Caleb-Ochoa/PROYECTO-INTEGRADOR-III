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
        public string[] GetInput()
        {
            return new string[]
            {
                txtUsuario.Text.Trim(), // line[0] - Reemplaza por el Name real de tu TextBox de Usuario
                txtContraseña.Text        // line[1] - El TextBox de contraseña que pusiste público
            };
        }

        /// Muestra un cuadro de diálogo en caso de datos incorrectos o bloqueos.
        /// </summary>
        public void RowError(string mensaje) // Nota: En tu CtlUsuario llamaste a "MostrarError"
        {
            MessageBox.Show(mensaje, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Si en tu CtlUsuario escribiste 'VistaLogin.MostrarError', usa este nombre:
        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Limpia el campo de contraseña si el intento falla.
        /// </summary>
        public void LimpiarPassword()
        {
            txtContraseña.Clear();
            txtContraseña.Focus();
        }

        private void btnIdioma_Click(object sender, EventArgs e)
        {
            Idioma.MostrarSelector(this);
        }
    }
}
