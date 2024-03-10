using System.Security.Cryptography;

namespace DiscountSystem.Extensions
{
    public static class CodeExtension
    {

        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        /// <summary>
        /// Generate random string code.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomCode(int length)
        {
            var charArray = chars.Distinct().ToArray();
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
                result[i] = charArray[RandomNumberGenerator.GetInt32(charArray.Length)];
            return new string(result);
        }
    }
}
