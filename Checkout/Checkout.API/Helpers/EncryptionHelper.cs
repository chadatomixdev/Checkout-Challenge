using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.API.Helpers
{
    public class EncryptionHelper
    {
        /// <summary>
        /// Generate private key from SHA512 hash
        /// </summary>
        /// <param name="concatenatedString"></param>
        /// <returns></returns>
        public static string GeneratePrivateKey(string concatenatedString)
        {
            // Generate Encrypted Data
            using (SHA512 hashCreator = SHA512.Create())
            {
                byte[] encryptedData = hashCreator.ComputeHash(Encoding.UTF8.GetBytes(concatenatedString));

                var generatedConsistent = new StringBuilder();
                for (int i = 0; i < encryptedData.Length; i++)
                    generatedConsistent.Append(encryptedData[i].ToString("X2"));

                return generatedConsistent.ToString().ToUpper();
            }
        }
    }
}