using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;        

namespace SISTEMA_INTEGRADOR_VOLUMEN_III
{
    public partial class Logui : Form
    {
        private PersonaRepository repository;

        public Logui()
        {
            InitializeComponent();

            repository = new PersonaRepository();

            txtContraseña.PasswordChar = '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtContraseña.Text.Trim();

            Persona personaEncontrada =
                repository.BuscarUsuario(usuario);

            if (personaEncontrada == null)
            {
                MessageBox.Show(
                    "Usuario no encontrado");

                return;
            }

            if (personaEncontrada.PasswordHash == password)
            {
                MessageBox.Show(
                    "Inicio de sesión exitoso");
            }
            else
            {
                MessageBox.Show(
                    "Contraseña incorrecta");
            }
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked)
            {
                txtContraseña.PasswordChar = '\0';
            }
            else
            {
                txtContraseña.PasswordChar = '*';
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" ||
            txtContraseña.Text.Trim() == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            Persona usuarioExistente = repository.BuscarUsuario(txtUsuario.Text);

            if (usuarioExistente != null)
            {
                MessageBox.Show( "El usuario ya existe");
                return;
            }

            Usuario nuevoUsuario = new Usuario(
                1,
                "Usuario",
                "0000",
                "correo@gmail.com",
                "000000",
                "Sin direccion",
                txtUsuario.Text.Trim(),
                txtContraseña.Text.Trim()
            );

            repository.Agregar(nuevoUsuario);

            MessageBox.Show("Cuenta creada correctamente");

            txtUsuario.Clear();
            txtContraseña.Clear();
        }
    }
}
