using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class CommonMethods
    {
       // public static string Key = "adef@@kfxcbv@";

        //public static string ConvertToEncrypt(string password)
        //{
        //    if (string.IsNullOrEmpty(password)) return "";
        //    password += Key;
        //    var passwordBytes = Encoding.UTF8.GetBytes(password);
        //    return Convert.ToBase64String(passwordBytes);
        //}


        private static string key = "b14ca5898a4e4142aace2ea2143a2410";
        public static string ConvertToEncrypt(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }


        public static string ConvertToDecrypt(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);//I have already defined "Key" in the above EncryptString function
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }















        //public static string ConvertToDecrypt(string base64EncodeData)
        //{
        //    if (string.IsNullOrEmpty(base64EncodeData)) return "";
        //    var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
        //    var result = Encoding.UTF8.GetString(base64EncodeBytes);
        //    result = result.Substring(0, result.Length - Key.Length);
        //    return result;
        //}
    }
}
