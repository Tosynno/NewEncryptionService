using System.Security.Cryptography;
using System.Text;

namespace NewEncryptionService.BusinessLogic
{
    public class GeneralClass
    {
        public string EncryptString(string key, string plainText)

        {

            byte[] iv = new byte[16];

            Console.WriteLine("IV is:", iv);

            byte[] array;

            Console.WriteLine(Convert.ToBase64String(iv));



            using (Aes aes = Aes.Create())

            {

                aes.Key = Encoding.UTF8.GetBytes(key);

                aes.IV = iv;

                aes.Mode = CipherMode.CBC;

                aes.Padding = PaddingMode.PKCS7;



                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);



                using (MemoryStream memoryStream = new MemoryStream())

                {

                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))

                    {

                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))

                        {

                            streamWriter.Write(plainText);

                            streamWriter.Flush();

                        }



                        array = memoryStream.ToArray();

                    }

                }

            }



            return Convert.ToBase64String(array);

        }



        public  string DecryptString(string key, string cipherText)
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
