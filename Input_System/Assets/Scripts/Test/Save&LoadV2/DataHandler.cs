using UnityEngine;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DataSpace
{
    // This script handles the data conversion and encryption
    // T represents any type of class rather than just one
    public class DataHandler<T> where T : class
    {
        // Declare variables
        private string dataDirPath = "";
        private string dataFileName = "";
        private bool useEncryption;
        private readonly string key = ""; // Must be 32 characters long for AES-256

        // Constructor with default values
        public DataHandler(string dataDirPath, string dataFileName, bool useEncryption, string encrpytionKey)
        {
            this.dataDirPath = dataDirPath;
            this.dataFileName = dataFileName;
            this.useEncryption = useEncryption;
            this.key = encrpytionKey;
        }

        // Returns Data
        public T Load()
        {
            // Use Path.Combine to account for different OS's having different path separators
            string fullPath = Path.Combine(dataDirPath, dataFileName);
            if (File.Exists(fullPath))
            {
                try
                {
                    // Load the serialized data from the file
                    string dataToLoad = "";
                    using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }

                    // Optionally decrypt the data
                    if (useEncryption)
                    {
                        dataToLoad = Decrypt(dataToLoad);
                    }

                    // Deserialize the data from Json back into C#
                    return JsonUtility.FromJson<T>(dataToLoad);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error occurred when trying to load data from file: {fullPath}\n{e}");
                }
            }
            return null;
        }

        // Takes in data
        public void Save(T data)
        {
            // use Path.Combine to account for different OS's having different path separators
            string fullPath = Path.Combine(dataDirPath, dataFileName);

            try
            {
                // Create directory the file will be written to if it doesn't already exist
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                // Serialize the C# data in Json (true for pretty print)
                string dataToStore = JsonUtility.ToJson(data, true);

                if (useEncryption)
                {
                    dataToStore = Encrypt(dataToStore);
                }

                // Write the serialized data to the file
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(dataToStore);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Error occurred while saving data to file: {fullPath}\n{e}");
            }
        }

        private string Encrypt(string plainText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.GenerateIV(); // Generate a new IV for each encryption
                byte[] iv = aes.IV;

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length); // Prepend IV to the ciphertext
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cs))
                        {
                            writer.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string Decrypt(string cipherText)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] iv = new byte[16];
            byte[] cipherBytes = new byte[fullCipher.Length - iv.Length];

            Array.Copy(fullCipher, iv, iv.Length);
            Array.Copy(fullCipher, iv.Length, cipherBytes, 0, cipherBytes.Length);

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;

                using (MemoryStream ms = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
