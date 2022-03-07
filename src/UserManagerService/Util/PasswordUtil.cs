namespace UserManagerService.Util;

using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

public class PasswordUtil {
    /// <return> Hashed password
    public static string Hash(string password, byte[] salt) {
        // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
    }

    public static byte[] CreateSalt() {
        // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
        return RandomNumberGenerator.GetBytes(128 / 8);
    }
}