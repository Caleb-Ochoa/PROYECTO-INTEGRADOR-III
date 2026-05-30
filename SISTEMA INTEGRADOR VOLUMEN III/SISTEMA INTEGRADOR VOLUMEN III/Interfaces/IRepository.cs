using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces
{
    internal interface IRepository<T>
    {
        List<T> GetAll();

        T? GetById(int id);

        void Add(T entity);

        void Update(T entity);
    }
}
