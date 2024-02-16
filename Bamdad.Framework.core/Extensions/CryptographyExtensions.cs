using Bamdad.Framework.core.Security.Cryptography;

namespace Bamdad.Framework.core.Extensions;
public static class CryptographyExtensions
{
    public static string Encrypt(this string plainText, string key)
    {
        return Encryption.EncryptString(plainText, key);
    }
    public static string Decrypt(this string cipherText, string key)
    {
        return Encryption.DecryptString(cipherText, key);
    }
}
