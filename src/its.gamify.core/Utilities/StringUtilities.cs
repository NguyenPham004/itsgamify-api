using System.Security.Cryptography;
using System.Text;

namespace its.gamify.core.Utilities
{
    public static class StringUtilities
    {
        public static string Hashing(this string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public static string GenerateRandomCode(int length)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new(length);

            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                for (int i = 0; i < length; i++)
                {
                    // Chuyển đổi byte ngẫu nhiên thành chỉ mục trong chuỗi validChars
                    int index = randomBytes[i] % validChars.Length;
                    result.Append(validChars[index]);
                }
            }

            return result.ToString();
        }

        public static string GenerateRandomCode()
        {
            return GenerateRandomCode(8);
        }
    }
}
