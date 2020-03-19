using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCryptoLib
{
    public static class AES
    {
        public static byte[] Encrypt(byte[] data, string password, int keySize = 256)
        {
            AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();
            aesProvider.Mode = CipherMode.CBC;
            aesProvider.Padding = PaddingMode.PKCS7;
            aesProvider.KeySize = keySize;
            aesProvider.GenerateIV();

            //We are not saving this hash so we do not need a salt.
            aesProvider.Key = new PasswordDeriveBytes(password, new byte[] { }).GetBytes(aesProvider.KeySize / 8);

            ICryptoTransform encrypter = aesProvider.CreateEncryptor();

            using (MemoryStream output = new MemoryStream())
            using (CryptoStream writer = new CryptoStream(output, encrypter, CryptoStreamMode.Write))
            {
                writer.Write(data, 0, data.Length);
                writer.FlushFinalBlock();
                byte[] encrypted = new byte[output.Length + 16];
                Buffer.BlockCopy(aesProvider.IV, 0, encrypted, 0, aesProvider.IV.Length);
                Buffer.BlockCopy(output.ToArray(), 0, encrypted, aesProvider.IV.Length, output.ToArray().Length);
                return encrypted;
            }
        }

        public static byte[] Decrypt(byte[] data, string password, int keySize = 256)
        {
            AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();
            aesProvider.Mode = CipherMode.CBC;
            aesProvider.Padding = PaddingMode.PKCS7;
            aesProvider.KeySize = keySize;
            aesProvider.IV = data.Take(16).ToArray();

            aesProvider.Key = new PasswordDeriveBytes(password, new byte[] { }).GetBytes(aesProvider.KeySize / 8);

            byte[] decrypted = new byte[data.Length - aesProvider.BlockSize / 8];
            ICryptoTransform decrypter = aesProvider.CreateDecryptor();

            using (MemoryStream input = new MemoryStream(data.Skip(16).ToArray()))
            using (CryptoStream reader = new CryptoStream(input, decrypter, CryptoStreamMode.Read))
            {
                int decryptedLength = reader.Read(decrypted, 0, decrypted.Length);
                return decrypted.Take(decryptedLength).ToArray();
            }
        }
    }
}
