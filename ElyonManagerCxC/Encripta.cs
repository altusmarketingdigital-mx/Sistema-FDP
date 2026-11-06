using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace ElyonManagerCxC
{
   public class Encripta
    {
        static System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        static RSACryptoServiceProvider sec = new RSACryptoServiceProvider();
        static byte[] bytString = null;
        static byte[] bytEncriptar = null;
        static byte[] bytDesEncriptar = null;
        static string key= "UN1v4F4ctur43";


        public static string Encriptar(string EncriptString)
        {
            string strEncriptar = null;
            if (!string.IsNullOrEmpty(EncriptString))
            {
                try
                {
                    bytString = ue.GetBytes(EncriptString);
                    bytEncriptar = sec.Encrypt(bytString, true);
                    strEncriptar = Convert.ToBase64String(bytEncriptar);
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("No se realizo la encripción " + ex.Message, "...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return strEncriptar;
        }
        public static string Desencriptar(string TextEncripted)
        {
            string strDesencriptar = null;
            if (!string.IsNullOrEmpty(TextEncripted))
            {
                try
                {
                    bytDesEncriptar = sec.Decrypt(Convert.FromBase64String(TextEncripted), true);
                    strDesencriptar = ue.GetString(bytDesEncriptar);
                }
                catch (Exception ex)
                {
                    //  MessageBox.Show("No se realizo la Desencripción " + ex.Message, "...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return strDesencriptar;
        }
        public static string Decrypt(string PlainText, string Password, string SaltValue, string HashAlgorithm, int PasswordIterations, string InitialVector, int KeySize)
        {
            try
            {
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);

                byte[] cipherTextBytes = Convert.FromBase64String(PlainText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(Password, saltValueBytes, HashAlgorithm, PasswordIterations);

                byte[] keyBytes = password.GetBytes(KeySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, InitialVectorBytes);

                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                return plainText;
            }
            catch (Exception e)
            {
                // MessageBox.Show("The typed information is wrong. Please, check it.", "FoS TeaM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }
        }
        public static string Encrypt(string PlainText, string Password, string SaltValue, string hashAlgorithm, int PasswordIterations, string InitialVector, int KeySize)
        {
            try
            {
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(PlainText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(Password, saltValueBytes, hashAlgorithm, PasswordIterations);

                byte[] keyBytes = password.GetBytes(KeySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, InitialVectorBytes);

                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                string cipherText = Convert.ToBase64String(cipherTextBytes);

                return cipherText;
            }
            catch
            {
                //  MessageBox.Show("The typed information is wrong. Please, check it.", "FoS TeaM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }
        }
        public static string EncriptarContraseña(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =cTransform.TransformFinalBlock(Arreglo_a_Cifrar,0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,0, ArrayResultado.Length);
        }
        public static string DesencriptarContraseña(string textoEncriptado)
        {
            byte[] keyArray;
            byte[] resultArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
           
            resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
                          
            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}