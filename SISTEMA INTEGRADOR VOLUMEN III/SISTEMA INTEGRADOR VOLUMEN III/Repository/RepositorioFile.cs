using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Repository
{
    internal class RepositorioFile<T> : IRepository<T> where T : class, new()
    {
        private readonly Func<string, T> FromText;
        public RepositorioFile(string source, Func<string, T> fromString)
        {
            this.Source = source;
            this.FromText = fromString;
        }
        public string Source { get; set; }
        public List<T> GetAll()
        {
            if (!File.Exists(Source))
            {
                return new List<T>();
            }
            return File.ReadAllLines(Source).Select(line => FromText(line)).ToList();
        }
        public void Sync(List<T> entities)
        {
            StringBuilder sb = new StringBuilder();
            foreach (T entity in entities)
            {
                sb.Append(entity.ToString());
            }
            File.WriteAllText(Source, sb.ToString());
        }
    }
}
