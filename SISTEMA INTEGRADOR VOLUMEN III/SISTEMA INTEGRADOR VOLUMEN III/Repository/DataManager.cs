using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Repository
{
    internal class DataManager <T> where T : class, new()
    {
        private readonly IRepository<T> _repo;

        public DataManager(IRepository<T> repo) => _repo = repo;

        public List<T> GetAll() => _repo.GetAll();

        public void Save(List<T> entities) => _repo.Sync(entities);

        /// <summary>
        /// Obtiene el siguiente Id sin usar reflexión: requiere que T tenga propiedad Id.
        /// Usa la interfaz IEntidad cuando sea posible; cae a reflexión de respaldo.
        /// </summary>
        public int GetNextId()
        {
            var entities = GetAll();
            if (!entities.Any()) return 1;

            int max = 0;
            foreach (var e in entities)
            {
                int id = 0;
                if (e is Interfaces.IEntidad ie)
                    id = ie.Id;
                else
                {
                    var prop = e.GetType().GetProperty("Id");
                    if (prop != null) id = (int)(prop.GetValue(e) ?? 0);
                }
                if (id > max) max = id;
            }
            return max + 1;
        }
    }
}
