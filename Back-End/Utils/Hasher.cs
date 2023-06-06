using System.Security.Cryptography;
using System.Text;

namespace Back_End.Utils
{
    public class Hasher
    {
       public static string GenerateHash(string input)
        {
          
            byte[] saltBytes = GenerateRandomSalt();

         
            string saltedInput = input + Convert.ToBase64String(saltBytes);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(saltedInput);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2")); 
                }

                return builder.ToString();
            }
        }

       public static byte[] GenerateRandomSalt()
        {
            byte[] saltBytes = new byte[16];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return saltBytes;
        }
    }
}
