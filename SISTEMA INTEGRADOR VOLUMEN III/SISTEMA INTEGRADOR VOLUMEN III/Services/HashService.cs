using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Services
{
    internal class HashService : IHashService
    {
        public string Hash(string textoPlano)
        {
            if (string.IsNullOrEmpty(textoPlano))
                throw new ArgumentException("No se puede hashear un texto vacío.");

            using SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(textoPlano));
            var sb = new StringBuilder(64);
            foreach (byte b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        public bool Verify(string textoPlano, string hashGuardado)
        {
            if (string.IsNullOrEmpty(textoPlano) || string.IsNullOrEmpty(hashGuardado))
                return false;
            // Comparación en tiempo constante para evitar timing attacks
            string calculado = Hash(textoPlano);
            return CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(calculado),
                Encoding.UTF8.GetBytes(hashGuardado));
        }
    }
}
