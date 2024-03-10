using DiscountSystem.Extensions;

namespace DiscountSystem.Services
{
    public class DiscountCodeService : IDiscountCodeService
    {

        private HashSet<string> generatedCodes = new HashSet<string>();


        /// </summary>
        /// <param name="count">The number of codes to generate.</param>
        /// <param name="length">The length of each generated code.</param>
        /// <returns>
        /// The task result indicates whether the codes were generated successfully.
        /// </returns>
        public bool GenerateCodes(int count, byte length)
        {
            try
            {
                char[] codeChars = new char[length];

                for (int i = 0; i < count; i++)
                {

                    string code = CodeExtension.GenerateRandomCode(length);

                    // Check if the generated code already exists
                    while (generatedCodes.Contains(code))
                    {
                        code = new string(codeChars);
                    }
                    generatedCodes.Add(code);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="code">The code to be used.</param>
        /// <returns>
        /// - 1 if the code was successfully used and removed from the collection.
        /// - 0 if the code was not found in the collection and thus not used.
        /// </returns>

        public byte UseCode(string code)
        {
            if (generatedCodes.Contains(code))
            {
                generatedCodes.Remove(code);
                return 1;
            }
            return 0;
        }


    }
}
