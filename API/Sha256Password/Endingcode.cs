using System.Security.Cryptography;
using System.Text;

namespace API.Sha256Password
{
    public class Endingcode
    {
        public static string ComputeSha256hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}

// Your other code (RegisterNewUser method and other classes) go here