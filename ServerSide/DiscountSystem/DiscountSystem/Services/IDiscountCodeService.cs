namespace DiscountSystem.Services
{
    public interface IDiscountCodeService
    {
        /// </summary>
        /// <param name="count">The number of codes to generate.</param>
        /// <param name="length">The length of each generated code.</param>
        /// <returns>
        /// The task result indicates whether the codes were generated successfully.
        /// </returns>
        bool GenerateCodes(int count, byte length);


        /// <summary>
        /// </summary>
        /// <param name="code">The code to be used.</param>
        /// <returns>
        /// - 1 if the code was successfully used and removed from the collection.
        /// - 0 if the code was not found in the collection and thus not used.
        /// </returns>

        byte UseCode(string code);
    }
}
