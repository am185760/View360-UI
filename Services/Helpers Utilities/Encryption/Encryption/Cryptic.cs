using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Encryption
{
    public static class Cryptic
    {
        //private static string key1 = "NcrView360Produk";
        private static string key1 = "";
        public static string MasterZipFile = "";
        public static string ConnectionZipFile = "";

        // Methods
        private static string DecryptString(string cipherText, byte[] Key, byte[] IV)
        {
            if ((cipherText == null) || (cipherText.Length <= 0))
            {
                throw new ArgumentNullException("cipherText");
            }
            if ((Key == null) || (Key.Length == 0))
            {
                throw new ArgumentNullException("Key");
            }
            if ((IV == null) || (IV.Length == 0))
            {
                throw new ArgumentNullException("Key");
            }
            using (RijndaelManaged managed = new RijndaelManaged())
            {
                managed.Key = Key;
                managed.IV = IV;
                managed.Mode = CipherMode.CBC;
                managed.Padding = PaddingMode.None;
                ICryptoTransform transform = managed.CreateDecryptor(managed.Key, managed.IV);
                using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(stream2, Encoding.Default))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public static string DecryptString(string inputText,string key)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(key);
                byte[] buffer2 = new byte[0x10];
                for (int i = 0; i < 0x10; i++)
                {
                    buffer2[i] = 0;
                }
                using (RijndaelManaged managed = new RijndaelManaged())
                {
                    managed.Key = bytes;
                    managed.IV = buffer2;
                    return DecryptString(inputText, managed.Key, managed.IV);
                }
            }
            catch(Exception ex)
            {
                return "";
            }
        }
        public static string DecryptString(string inputText)
        {
            if (String.IsNullOrEmpty(key1))
                key1 = GetDataKey();
            return DecryptString(inputText, key1);
        }
        private static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            if ((plainText == null) || (plainText.Length <= 0))
            {
                throw new ArgumentNullException("plainText");
            }
            if ((Key == null) || (Key.Length == 0))
            {
                throw new ArgumentNullException("Key");
            }
            if ((IV == null) || (IV.Length == 0))
            {
                throw new ArgumentNullException("Key");
            }
            using (RijndaelManaged managed = new RijndaelManaged())
            {
                managed.Key = Key;
                managed.IV = IV;
                managed.Mode = CipherMode.CBC;
                managed.Padding = PaddingMode.Zeros;
                ICryptoTransform transform = managed.CreateEncryptor(managed.Key, managed.IV);
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(stream2, Encoding.Default))
                        {
                            writer.Write(plainText);
                        }
                        return stream.ToArray();
                    }
                }
            }
        }
        public static string EncryptString(string inputText, string key)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(key);
                byte[] buffer2 = new byte[0x10];
                for (int i = 0; i < 0x10; i++)
                {
                    buffer2[i] = 0;
                }
                using (RijndaelManaged managed = new RijndaelManaged())
                {
                    managed.KeySize = 256;
                    managed.Key = bytes;
                    managed.IV = buffer2;
                    return Convert.ToBase64String(EncryptStringToBytes(inputText, managed.Key, managed.IV));
                }
            }
            catch(Exception ex)
            {
                return "";
            }
        }
        public static string EncryptString(string inputText)
        {
            if (String.IsNullOrEmpty(key1))
                key1 = GetDataKey();
            return EncryptString(inputText, key1);
        }

        public static string GetDataKey()
        {
            try
            {
                string ConnectionKey = Helper.ConstractKey(false);
                string EncryptedConnectionStr = Helper.GetValueFromRegistry(@"HKEY_LOCAL_MACHINE\SOFTWARE\NCR\EV360", "ConnectionString");
                string DecryptedConnectionStr = DecryptString(EncryptedConnectionStr, ConnectionKey);
                string EncryptedDataKey = Helper.GetEncryptedDataKeyFromDB(DecryptedConnectionStr);
                string MasterKey = Helper.ConstractKey(true);
                string DecryptedDataKey = DecryptString(EncryptedDataKey, MasterKey);
                return DecryptedDataKey;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

    }
}
