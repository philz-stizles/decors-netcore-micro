using Decors.Application.Contracts.Services;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Decors.Infrastructure.Services.Security
{
    public class HasherService : IHasherService
    {
        public string CreateHMACSHA256(string toHash, string key)
        {
            byte[] keyByte = Encoding.Default.GetBytes(key);
            using (HMACSHA256 sha256 = new HMACSHA256(keyByte))
            {
                Byte[] originalByte = Encoding.Default.GetBytes(toHash);
                Byte[] encodedByte = sha256.ComputeHash(originalByte);
                sha256.Clear();

                string hash = BitConverter.ToString(encodedByte).Replace("-", "").ToLower();
                return hash;
            }
        }

        public string CreateMD5(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                return Encoding.ASCII.GetString(result);
            }
        }

        public string CreateMD5Crypto(string input, string key)
        {
            string encryptedText = "";
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.KeySize = 128;
            des.Mode = CipherMode.CBC;
            des.Padding = PaddingMode.PKCS7;

            byte[] md5Bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(key));

            byte[] ivBytes = new byte[8];


            des.Key = md5Bytes;
            des.IV = ivBytes;
            byte[] clearBytes = Encoding.Unicode.GetBytes(input);

            ICryptoTransform ct = des.CreateEncryptor();
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                encryptedText = Convert.ToBase64String(ms.ToArray());
            }

            return encryptedText;
        }
    }
}
