using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Repository
{
    internal class RepositorioFile<T> : IRepository<T> where T : class, new()
    {
        private readonly Func<string, T> _parser;

        public string Source { get; }

        public RepositorioFile(string source, Func<string, T> parser)
        {
            Source = source;
            _parser = parser;
        }

        public List<T> GetAll()
        {
            if (!File.Exists(Source))
                return new List<T>();

            var resultado = new List<T>();
            string[] lineas = File.ReadAllLines(Source);
            for (int i = 0; i < lineas.Length; i++)
            {
                string linea = lineas[i].Trim();
                if (string.IsNullOrWhiteSpace(linea)) continue;
                try
                {
                    resultado.Add(_parser(linea));
                }
                catch (Exception ex)
                {
                    LogError($"[RepositorioFile] Error en '{Source}' línea {i + 1}: {ex.Message}");
                }
            }
            return resultado;
        }

        public void Sync(List<T> entities)
        {
            try
            {
                string tmpPath = Source + ".tmp";
                File.WriteAllLines(tmpPath, entities.Select(e => e.ToString() ?? string.Empty));
                if (File.Exists(Source)) File.Delete(Source);
                File.Move(tmpPath, Source);
            }
            catch (Exception ex)
            {
                throw new IOException($"No se pudo guardar '{Source}': {ex.Message}", ex);
            }
        }

        private static void LogError(string mensaje)
        {
            try
            {
                string logPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "errores.log");
                File.AppendAllText(logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {mensaje}{Environment.NewLine}");
            }
            catch { }
        }
    }
}
