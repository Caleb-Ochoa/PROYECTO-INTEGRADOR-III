using SISTEMA_INTEGRADOR_VOLUMEN_III.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SISTEMA_INTEGRADOR_VOLUMEN_III.Services
{
    internal class HashService : IHashService
    {
        public string GenerarHash(string texto)
        {
            
        
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(texto));

                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    
    }
}
