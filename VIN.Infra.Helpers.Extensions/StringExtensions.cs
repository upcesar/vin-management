using System.Globalization;
using System.Linq;
using System.Text;

namespace VIN.Infra.Helpers.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Remove special characters (Diacritics) in a string
        /// </summary>
        /// <param name="text">string to be Removed the Diacritics characters</param>
        /// <returns>String without Diacritics</returns>
        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                            .ToArray();

            return new string(chars).Normalize(NormalizationForm.FormC);
        }
    }
}
