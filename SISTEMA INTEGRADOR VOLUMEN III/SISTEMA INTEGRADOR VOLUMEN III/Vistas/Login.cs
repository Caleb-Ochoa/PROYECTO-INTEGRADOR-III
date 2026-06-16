using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;        

namespace SISTEMA_INTEGRADOR_VOLUMEN_III
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
                txtUsuario.Text.Trim(), txtContraseña.Text        
            };
        }
       
        public void RowError(string mensaje) 
        {
            MessageBox.Show(mensaje, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
       
        public void LimpiarPassword()
        {
            txtContraseña.Clear();
            txtContraseña.Focus();
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

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = !chkMostrar.Checked;
        }
    }
}
