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
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Idioma.Cargar("es");

            // El loop principal corre aquí — nunca termina hasta que
            // el usuario cierra la app completamente
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