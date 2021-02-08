using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RentNow.Domain.Entities
{
    public class Credentials : BaseEntity<Guid>
    {
        public string Login { get; set; }
        public string Password
        {
            get => Password;
            set
            {
                Salt = GenerateRandomSalt();
                Password = Hash(value, Salt);
            }
        }
        public string Salt { get; set; }

        public bool isAuthentic(string password)
        {
            var hashPwd = Hash(password, Salt);
            return Password.Equals(hashPwd);
        }

        private string Hash(string pwd, string salt)
        {
            var algorithm = SHA256.Create();
            var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(pwd + salt));
            var builder = new StringBuilder();
            for(var i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        private string GenerateRandomSalt()
        {
            var regex = new Regex("[a-zA-z0-9]");
            var salt = new byte[128 / 8];
            using(var rng = RandomNumberGenerator.Create())
            {

                rng.GetBytes(salt);
            }

            return string.Join("", regex.Matches(Convert.ToBase64String(salt)).Cast<Match>().Select(e => e.Value).ToArray());
        }
    }
}
