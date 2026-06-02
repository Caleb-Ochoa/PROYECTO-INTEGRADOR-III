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
            using SHA256 sha256 = SHA256.Create();

            byte[] bytesTexto =Encoding.UTF8.GetBytes(textoPlano);

            byte[] bytesHash =sha256.ComputeHash(bytesTexto);

            StringBuilder resultado =new StringBuilder();

            foreach (byte b in bytesHash)
            {
                resultado.Append(b.ToString("x2"));
            }

            return resultado.ToString();
        }

        public bool Verify(string textoPlano, string hashGuardado)
        {
            string hashCalculado = Hash(textoPlano);
            return hashCalculado == hashGuardado;
        }
    }
}
