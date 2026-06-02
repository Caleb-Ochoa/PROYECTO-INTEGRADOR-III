using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Repository
{
    internal class DataManager <T> where T : class, new()
    {
        private readonly IRepository<T> repository;

        public DataManager(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public List<T> GetAll()
        {
            return repository.GetAll();
        }
        public void Save(List<T> entities)
        {
            repository.Sync(entities);

        }
        public int GetNextId()
        {
            List<T> entities = GetAll();
            if (entities.Count == 0) return 1;
            int maxId = 0;
            foreach (T entity in entities)
            {
                var idProperty = entity.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    int idValue = (int)idProperty.GetValue(entity);
                    if (idValue > maxId)
                    {
                        maxId = idValue;
                    }
                }
            }
            return maxId + 1;
        }
    }
}
