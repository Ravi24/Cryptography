using System;
using System.Text;
using System.Security.Cryptography;

namespace CryptographyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string x= EncryptionExample();
            
            Console.WriteLine("hashed password ={0}", x);
            Console.ReadLine();
        }
        public static string EncryptionExample()
        {
            Console.WriteLine("Enter a password: ");
            string password = Console.ReadLine();
            // generate a 128 bit sal using PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            StringBuilder xb = new StringBuilder();
            for(int x= 0; x< salt.Length; x++)
            {
                xb.Append(salt[x].ToString("x2"));
            }
            Console.WriteLine("Salt = {0}", xb.ToString());
            using (SHA512 sha512hash = SHA512.Create())
            {
                byte[] bytes = sha512hash.ComputeHash(Encoding.UTF8.GetBytes(password+xb.ToString()));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString());
                }
                return sb.ToString();
            }
            
        }
    }
}
