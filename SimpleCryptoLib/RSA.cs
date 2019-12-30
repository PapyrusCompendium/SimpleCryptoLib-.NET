using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCryptoLib
{
    public static class RSA
    {
        public static RSACryptoServiceProvider rsaProvider = null;

        public static void CheckKeys()
        {
            if (rsaProvider == null)
                throw new ArgumentOutOfRangeException("Null keys", "Must generate keys.");
        }

        public static byte[] Encrypt(string data)
        {
            CheckKeys();
            return rsaProvider.Encrypt(Encoding.UTF8.GetBytes(data), false);
        }

        public static string Decrypt(byte[] data)
        {
            CheckKeys();
            return Encoding.UTF8.GetString(rsaProvider.Decrypt(data, false));
        }

        public static string Decrypt(string data)
        {
            CheckKeys();
            return Encoding.UTF8.GetString(rsaProvider.Decrypt(System.Text.Encoding.UTF8.GetBytes(data), false));
        }

        public static byte[] SignData(byte[] data)
        {
            CheckKeys();
            return rsaProvider.SignData(data, CryptoConfig.MapNameToOID("SHA512"));
        }

        public static bool VerifySignedData(byte[] data, byte[] signiture)
        {
            CheckKeys();
            return rsaProvider.VerifyData(data, CryptoConfig.MapNameToOID("SHA512"), signiture);
        }

        public static void ImportKey(RSAParameters key) => rsaProvider.ImportParameters(key);

        public static void GenerateKeys(out RSAParameters publicKey, out RSAParameters privateKey, int keySize = 4096)
        {
            rsaProvider = new RSACryptoServiceProvider(keySize);
            publicKey = rsaProvider.ExportParameters(false);
            privateKey = rsaProvider.ExportParameters(true);
        }
    }
}