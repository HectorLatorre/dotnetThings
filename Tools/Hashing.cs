using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace firstapp.Tools
{
    public class Hashing
    {

        public Hashing()
        {
        }

        public string GetSalt(){
            byte[] salt = new byte[128/8];

            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public string Hash(string text, string sal){
			string resultado = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: text,
                salt: Convert.FromBase64String(sal),
				prf: KeyDerivationPrf.HMACSHA1,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));


            return resultado;
        }
    }
}
