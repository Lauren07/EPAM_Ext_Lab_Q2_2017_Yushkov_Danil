using System;
using System.Security.Cryptography;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public Guid HashPassword { get; set; }
        public Role Role { get; set; }

        public string GenerateHashPass(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }

            return hash;
        }

        public void SetHashPassword(string password)
        {
            HashPassword = new Guid(GenerateHashPass(password));
        }

        public bool PassIsMatch(string secondPassword)
        {
            return HashPassword.Equals(new Guid(GenerateHashPass(secondPassword)));
        }
    }
}
