using System;
using System.Security.Cryptography;
using System.Text;

namespace PIV_PF_ProyectoFinal.Utils
{
    public class Cifrado
    {
        // Clave y vector de inicialización (IV) para el algoritmo AES
        private string clave = "LastKeyProgramming210901"; // La clave debe tener 16, 24 o 32 caracteres para AES (128, 192 o 256 bits)
        private string iv = "LastVector662200"; // El IV debe tener 16 caracteres para AES

        /// <summary>
        /// Método para encriptar con AES
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public string EncriptarAES(string texto)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clave);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                byte[] textoPlano = Encoding.UTF8.GetBytes(texto);

                byte[] textoEncriptado = encryptor.TransformFinalBlock(textoPlano, 0, textoPlano.Length);

                return Convert.ToBase64String(textoEncriptado);
            }
        }


        /// <summary>
        /// Método para desencriptar con AES
        /// </summary>
        /// <param name="textoEncriptado"></param>
        /// <returns></returns>
        public string DesencriptarAES(string textoEncriptado)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clave);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                byte[] textoEncriptadoBytes = Convert.FromBase64String(textoEncriptado);

                byte[] textoDesencriptado = decryptor.TransformFinalBlock(textoEncriptadoBytes, 0, textoEncriptadoBytes.Length);

                return Encoding.UTF8.GetString(textoDesencriptado);
            }
        }

    }
}