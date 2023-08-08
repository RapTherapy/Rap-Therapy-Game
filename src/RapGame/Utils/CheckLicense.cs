using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using RapGame.Models;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RapGame.Utils
{
    public class CheckLicense
    {
        private readonly AppSettings _appSettings;
        private readonly JsonSerializer _serializer;

        public CheckLicense(
            AppSettings appSettings,
            JsonSerializer serializer)
        {
            _appSettings = appSettings;
            _serializer = serializer;
        }

        public string GetLicencePath(string relativePath)
        {
            return Path.GetFullPath(
                        Path.Combine(
                            _appSettings.PathToLicence.BasePath
                            ?? string.Empty,
                            _appSettings.PathToLicence.Path
                            ?? string.Empty,
                            relativePath))
                    .Replace("\\", "/");
        }

        public Licence GetLicence(string key)
        {

            var file = new FileInfo(GetLicencePath(key + ".json"));
            Licence result = new();

            if (file.Exists)
            {
                using StreamReader sr = file.OpenText();
                result = (Licence)_serializer.Deserialize(sr, typeof(Licence));
            }         
            result.Expired = (DecryptString(_appSettings.Key, result.Expired.ToString()));
            return result;
        }

        public void SetUpLicence(string key)
        {
            var date = DateTime.Now.AddYears(1);
            var value = EncryptString(_appSettings.Key, date.ToString());

            var file = new FileInfo(GetLicencePath(key + ".json"));
            Licence licence = new() { Expired = value };

            if (!file.Exists)
            {
                return;
            }

            using (var sw = file.CreateText())
            {
                _serializer.Serialize(sw, licence);
            }
        }

        public bool IsLicenceExpired(DateTime Licence)
        {
            if(Licence < DateTime.Now)
            {
                return true;
            }
            return false;
        }

        private string EncryptString(string key, string plainText)
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

        private string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
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
    }
}