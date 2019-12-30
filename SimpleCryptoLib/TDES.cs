using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCryptoLib
{
    public static class TDES
    {
        public static byte[] Encrypt(string plain, string password, int keySize = 64)
        {
            TripleDESCryptoServiceProvider desProvider = new TripleDESCryptoServiceProvider();
            desProvider.Mode = CipherMode.CBC;
            desProvider.Padding = PaddingMode.PKCS7;
            desProvider.KeySize = keySize;
            desProvider.GenerateIV();

            desProvider.Key = new PasswordDeriveBytes(password, new byte[] { }).GetBytes(desProvider.KeySize / 8);

            byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plain);
            ICryptoTransform encrypter = desProvider.CreateEncryptor();

            using (MemoryStream output = new MemoryStream())
            using (CryptoStream writer = new CryptoStream(output, encrypter, CryptoStreamMode.Write))
            {
                writer.Write(plainBytes, 0, plainBytes.Length);
                writer.FlushFinalBlock();
                byte[] Encrypted = new byte[output.Length + desProvider.BlockSize / 8];
                Buffer.BlockCopy(desProvider.IV, 0, Encrypted, 0, desProvider.IV.Length);
                Buffer.BlockCopy(output.ToArray(), 0, Encrypted, desProvider.IV.Length, output.ToArray().Length);
                return Encrypted;
            }
        }

        public static string Decrypt(byte[] data, string password, int keySize = 64)
        {
            TripleDESCryptoServiceProvider desProvider = new TripleDESCryptoServiceProvider();
            desProvider.Mode = CipherMode.CBC;
            desProvider.Padding = PaddingMode.PKCS7;
            desProvider.KeySize = keySize;
            desProvider.IV = data.Take(desProvider.BlockSize / 8).ToArray();

            desProvider.Key = new PasswordDeriveBytes(password, new byte[] { }).GetBytes(desProvider.KeySize / 8);

            byte[] decrypted = new byte[data.Length - desProvider.BlockSize / 8];
            ICryptoTransform decrypter = desProvider.CreateDecryptor();

            using (MemoryStream input = new MemoryStream(data.Skip(desProvider.BlockSize / 8).ToArray()))
            using (CryptoStream reader = new CryptoStream(input, decrypter, CryptoStreamMode.Read))
            {
                reader.Read(decrypted, 0, decrypted.Length);
                return System.Text.Encoding.UTF8.GetString(decrypted);
            }
        }
    }
}
