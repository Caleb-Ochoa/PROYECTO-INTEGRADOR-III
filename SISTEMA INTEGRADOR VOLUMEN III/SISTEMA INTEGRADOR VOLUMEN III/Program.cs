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
            Idioma.Cargar("es"); // Carga el idioma al iniciar la aplicación);

            // 2. Crear las dependencias e infraestructura (Archivos, Repositorios, Servicios)
            IRepository<Usuario> repoUsuario = new RepositorioFile<Usuario>("usuarios.txt", Usuario.FromText);
            DataManager<Usuario> dataManager = new DataManager<Usuario>(repoUsuario);
            IHashService hashService = new HashService();
            IAuthService authService = new AuthService(dataManager, hashService);

            // 3. Pasarle el control al CtlUsuario
            // Tu constructor de CtlUsuario ejecutará internamente el Application.Run() correcto
            CtlUsuario ctlUsuario = new CtlUsuario(dataManager, authService);

            // 4. [Opcional] Flujo posterior al Login exitoso
            // Cuando las pantallas controladas por CtlUsuario se cierren con éxito, el código seguirá aquí:
            if (ctlUsuario.UsuarioAutenticado != null)
            {
                // Aquí puedes iniciar tu formulario de menú principal si lo tienes, por ejemplo:
                // Application.Run(new FrmMenuPrincipal(ctlUsuario.UsuarioAutenticado));
                Application.Run(new MenuPrincipal(ctlUsuario.UsuarioAutenticado));
            }
        }
    }
}