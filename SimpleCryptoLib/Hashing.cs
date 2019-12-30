using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCryptoLib
{
    public static class Hashing
    {
        public static string GetString(byte[] data) => Encoding.UTF8.GetString(data);

        public static string Sha1String(byte[] data) => BitConverter.ToString(new SHA1Managed().ComputeHash(data)).Replace("-", "");
        public static string Sha1String(string data) => Sha1String(Encoding.UTF8.GetBytes(data));
        public static byte[] Sha1(byte[] data) => new SHA1Managed().ComputeHash(data);
        public static byte[] Sha1(string data) => Sha1(Encoding.UTF8.GetBytes(data));

        public static string Sha256String(byte[] data) => BitConverter.ToString(new SHA256Managed().ComputeHash(data)).Replace("-", "");
        public static string Sha256String(string data) => Sha256String(Encoding.UTF8.GetBytes(data));
        public static byte[] Sha256(byte[] data) => new SHA256Managed().ComputeHash(data);
        public static byte[] Sha256(string data) => Sha256(Encoding.UTF8.GetBytes(data));

        public static string Sha384String(byte[] data) => BitConverter.ToString(new SHA384Managed().ComputeHash(data)).Replace("-", "");
        public static string Sha384String(string data) => Sha384String(Encoding.UTF8.GetBytes(data));
        public static byte[] Sha384(byte[] data) => new SHA384Managed().ComputeHash(data);
        public static byte[] Sha384(string data) => Sha384(Encoding.UTF8.GetBytes(data));

        public static string Sha512String(byte[] data) => BitConverter.ToString(new SHA512Managed().ComputeHash(data)).Replace("-", "");
        public static string Sha512String(string data) => Sha512String(Encoding.UTF8.GetBytes(data));
        public static byte[] Sha512(byte[] data) => new SHA512Managed().ComputeHash(data);
        public static byte[] Sha512(string data) => Sha512(Encoding.UTF8.GetBytes(data));

        public static string Md5String(byte[] data) => BitConverter.ToString(new MD5Cng().ComputeHash(data)).Replace("-", "");
        public static string Md5String(string data) => Md5String(Encoding.UTF8.GetBytes(data));
        public static byte[] Md5(byte[] data) => new MD5Cng().ComputeHash(data);
        public static byte[] Md5(string data) => Md5(Encoding.UTF8.GetBytes(data));

        public static string RipemdString(byte[] data) => BitConverter.ToString(new RIPEMD160Managed().ComputeHash(data)).Replace("-", "");
        public static string RipemdString(string data) => RipemdString(Encoding.UTF8.GetBytes(data));
        public static byte[] Ripemd(byte[] data) => new RIPEMD160Managed().ComputeHash(data);
        public static byte[] Ripemd(string data) => Ripemd(Encoding.UTF8.GetBytes(data));
    }
}