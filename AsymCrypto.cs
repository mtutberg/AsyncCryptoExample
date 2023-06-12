using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymCryptoExample
{
    internal static class AsymCrypto
    {
        public static void GenerateKey()
        {
            RSA rsa = RSA.Create();
            RSAParameters rsaparameters = rsa.ExportParameters(true); //Generate Private and Public Keys
            File.WriteAllBytes("Modulus.txt", rsaparameters.Modulus); //Write Public Key to File
            File.WriteAllBytes("Exponent.txt",rsaparameters.Exponent); //Write Public Key to File
            File.WriteAllBytes("D.txt", rsaparameters.D); //Write Private Key to File
            File.WriteAllBytes("P.txt", rsaparameters.P); //Write Private Key to File
            File.WriteAllBytes("Q.txt", rsaparameters.Q); //Write Private Key to File
            File.WriteAllBytes("DP.txt", rsaparameters.DP); //Write Private Key to File
            File.WriteAllBytes("DQ.txt", rsaparameters.DQ); //Write Private Key to File
            File.WriteAllBytes("InverseQ.txt", rsaparameters.InverseQ); //Write Private Key to File
            rsa.Dispose();
        }

        public static void Encrypt(String txt)
        {
            RSA rsa = RSA.Create();
            RSAParameters rsaparameters = new RSAParameters();
            rsaparameters.Modulus = File.ReadAllBytes("Modulus.txt"); //Read Public Key from File
            rsaparameters.Exponent = File.ReadAllBytes("Exponent.txt"); //Read Public Key from File
            rsa.ImportParameters(rsaparameters); //Construct Public Key
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            byte[] encryptedtext = rsa.Encrypt(buffer, RSAEncryptionPadding.Pkcs1); //Encrypt text using Public Key
            rsa.Dispose();
            File.WriteAllBytes("Encrypted.txt", encryptedtext);
        }

        public static String Decrypt()
        {
            RSA rsa = RSA.Create();
            RSAParameters rsaparameters = new RSAParameters();
            rsaparameters.Modulus = File.ReadAllBytes("Modulus.txt"); //Read Public Key from File
            rsaparameters.Exponent = File.ReadAllBytes("Exponent.txt"); //Read Public Key from File
            rsaparameters.D = File.ReadAllBytes("D.txt"); //Read Private Key from File
            rsaparameters.P = File.ReadAllBytes("P.txt"); //Read Private Key from File
            rsaparameters.Q = File.ReadAllBytes("Q.txt"); //Read Private Key from File
            rsaparameters.DP = File.ReadAllBytes("DP.txt"); //Read Private Key from File
            rsaparameters.DQ = File.ReadAllBytes("DQ.txt"); //Read Private Key from File
            rsaparameters.InverseQ = File.ReadAllBytes("InverseQ.txt"); //Read Private Key from File
            rsa.ImportParameters(rsaparameters); //Construct Private Key
            byte[] encryptedtext = File.ReadAllBytes("Encrypted.txt");//Retrieve the encrypted text
            byte[] buffer = rsa.Decrypt(encryptedtext, RSAEncryptionPadding.Pkcs1); //Decrypt the encrypted text
            rsa.Dispose();
            String txt = System.Text.Encoding.UTF8.GetString(buffer);
            return txt;
        }

        public static String DecryptWithoutPrivateKey()
        {
            RSA rsa = RSA.Create();
            RSAParameters rsaparameters = new RSAParameters();
            rsaparameters.Modulus = File.ReadAllBytes("Modulus.txt"); //Read Public Key from File
            rsaparameters.Exponent = File.ReadAllBytes("Exponent.txt"); //Read Public Key from File
            rsa.ImportParameters(rsaparameters); //Construct Private Key
            byte[] encryptedtext = File.ReadAllBytes("Encrypted.txt");//Retrieve the encrypted text
            byte[] buffer = rsa.Decrypt(encryptedtext, RSAEncryptionPadding.Pkcs1); //Decrypt the encrypted text
            rsa.Dispose();
            String txt = System.Text.Encoding.UTF8.GetString(buffer);
            return txt;
        }
    }
}
