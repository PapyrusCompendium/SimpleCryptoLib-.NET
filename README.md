# SimpleCryptoLib .NET
[![Github All Releases](https://img.shields.io/github/downloads/PapyrusCompendium/SimpleCryptoLib-.NET/total.svg)]()
[![Github Issues](https://img.shields.io/github/issues/PapyrusCompendium/SimpleCryptoLib-.NET.svg)]()
[![Github Stars](https://img.shields.io/github/stars/PapyrusCompendium/SimpleCryptoLib-.NET.svg)]()
[![Github License](https://img.shields.io/github/license/PapyrusCompendium/SimpleCryptoLib-.NET.svg)]()

This is a simplified implementation of cryptography in .NET. This supporrts the following algorithms;
* Sha1
* Sha256
* Sha384
* Sha512
* MD5
* RIPEMD160
* RSA
* AES
* DES
* TDES
* Generate Secure Token
* SnowFlakeID

# How do I use this?
This is pretty straight forward to use, everything is built with the intention to be quick and painless to use. AES Example;
```cs
    class Program
    {
        static void Main(string[] args)
        {
            byte[] cipherText = AES.Encrypt(Encoding.UTF8.GetBytes("Data to encrypt!"), "MySuperSecurePassword");
            string plainText = Encoding.UTF8.GetString(AES.Decrypt(cipherText, "MySuperSecurePassword"));
        }
    }
```

# Bugs and issues
If you encounter and bugs or issues, feel free to open an issue on GitHub. I will address these issues as soon as I can.