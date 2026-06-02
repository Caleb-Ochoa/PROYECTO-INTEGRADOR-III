using SISTEMA_INTEGRADOR_VOLUMEN_III.Models;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Repository;
using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using SISTEMA_INTEGRADOR_VOLUMEN_III;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Controller
{
    internal class CtlUsuario
    {
        public Login Vista { get; set; }

        private DataManager<Usuario> dataManager;
        private List<Usuario> usuarios;

        public CtlUsuario(DataManager<Usuario> dataManager, Login vista)
        {
            this.dataManager = dataManager;
            this.Vista = vista;
            this.usuarios = dataManager.GetAll();

            vista.button1.Click += (sender, e) =>
            {
                Add();
                Save();
            };
            Application.Run(Vista);
        }
        private void Add()
        {
            string[] line = Vista.GetInput();
            Models.Usuario usuario = new Models.Usuario
            {
                Id = dataManager.GetNextId(),
                Nombre = line[0],
                Documento = line[1],
                CorreoElectronico = line[2],
                Telefono = line[3],
                Direccion = line[4],
                Username = line[5],
                PasswordHash = (new HashService()).Hash(line[6]),
                Rol = (Enums.Rol)Enum.Parse(typeof(Enums.Rol), line[7]),
                Estado = (Enums.EstadoUsuario)Enum.Parse(typeof(Enums.EstadoUsuario), line[8])

            };
            usuarios.Add(usuario);
        }

        private void Save()
        {
            dataManager.Save(usuarios);
        }



        //private string repositoryName= "usuarios.txt";
        //private IRepository<Models.Usuario> repository ;
        //private List<Models.Usuario> usuarios;

        //public CtlUsuario(IRepository<Models.Usuario> repository, Login vista)
        //{
        //    this.repository = repository;
        //    this.usuarios = new List<Models.Usuario>();
        //    this.Vista = vista; 

        //    vista.button1.Click += (sender, e) =>
        //    {
        //        Add();
        //        Save();
        //    };

        //    Application.Run(Vista);
        //}
        //public int SetId()
        //{
        //    if (!File.Exists(repositoryName)) return 1;

        //    StreamReader reader = new StreamReader(repositoryName);
        //    int endId = 0;
        //    while (!reader.EndOfStream)
        //    {
        //        string linea = reader.ReadLine();
        //        int index = linea.IndexOf(',');
        //        if (index != -1)
        //        {
        //            int cad = int.Parse(linea.Substring(0, index));
        //            if (endId < cad)
        //            {
        //                endId = cad;
        //            }
        //        }
        //    }
        //    reader.Close();
        //    return endId + 1;
        //}

        //void Add()
        //{
        //    string[] line = Vista.GetInput();
        //    Models.Usuario usuario = new Models.Usuario
        //    {
        //        Id = SetId(),
        //        Nombre = line[1],
        //        Documento = line[2],
        //        CorreoElectronico = line[3],
        //        Telefono = line[4],
        //        Direccion = line[5],
        //        Username = line[6],
        //        PasswordHash = (new HashService()).Hash(line[7]),
        //        Rol = (Enums.Rol)Enum.Parse(typeof(Enums.Rol), line[8]),
        //        Estado = (Enums.EstadoUsuario)Enum.Parse(typeof(Enums.EstadoUsuario), line[9])

        //    };
        //    usuarios.Add(usuario);
        //}

        //private void Save()
        //{
        //    repository.Sync(usuarios);
        //}

        //public void GetRepositoryName()
        //{
        //    repositoryName = "usuarios.txt";
        //}
    }
}
