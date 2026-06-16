using SISTEMA_INTEGRADOR_VOLUMEN_III.Controller;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Services;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Vistas;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) =>MessageBox.Show(e.Exception.ToString(), "Error no manejado");
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>MessageBox.Show(e.ExceptionObject.ToString(), "Error crítico");

            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            ApplicationConfiguration.Initialize();

            while (true)
            {
                IRepository<Usuario> repo = new RepositorioFile<Usuario>("usuarios.txt", Usuario.FromText);
                DataManager<Usuario> dm = new DataManager<Usuario>(repo);
                IHashService hash = new HashService();
                IAuthService auth = new AuthService(dm, hash);

                CtlUsuario ctlUsuario = new CtlUsuario(dm, auth);

                if (ctlUsuario.UsuarioAutenticado == null)
                    break;

                MenuPrincipal menu = new MenuPrincipal(ctlUsuario.UsuarioAutenticado);

                // Capturamos el valor ANTES de que el form se destruya
                bool cerroSesion = false;
                menu.FormClosed += (s, e) => cerroSesion = menu.CerroSesion;

                Application.Run(menu);

                if (!cerroSesion)
                    break;
            }
        }
    }
}