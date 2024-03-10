using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTransmissaoWhatsApi.Models
{
    public static class Criptografias
    {
        private static readonly byte[] chave = new byte[32]; // Chave de 256 bits (32 bytes)
        private static readonly byte[] iv = new byte[16];   // IV de 128 bits (16 bytes)

        static Criptografias()
        {
            // Definindo uma chave fixa de tamanho adequado
            byte[] chaveFixa = Encoding.UTF8.GetBytes("MinhaChaveDeTeste123");

            // Preenchendo a chave com a chave fixa, repetindo-a, se necessário
            for (int i = 0; i < chave.Length; i++)
            {
                chave[i] = chaveFixa[i % chaveFixa.Length];
            }

            // Definindo um IV fixo (preenchido com zeros)
            // Para produção, o IV deve ser único para cada mensagem criptografada
            // Aqui, estamos usando um IV fixo apenas para fins de teste
            iv = new byte[16]; // IV de 128 bits
        }

        public static string Criptografar(string texto)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = chave;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(texto);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Descriptografar(string textoCriptografado)
        {
            byte[] cipherText = Convert.FromBase64String(textoCriptografado);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = chave;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
