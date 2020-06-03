using System;

namespace VIN.Helpers.Extensions
{
    /// <summary>
    /// Helper for Enumerators
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Convert a string to its respective Enumerator.
        /// </summary>
        /// <param name="stringValue">String value to find and get the Enum</param>
        /// <returns>Enum value for the string or default</returns>
        public static T? ToEnum<T>(this string stringValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");

            if (Enum.TryParse(stringValue?.ToUpper(), out T enumeratorValue) || Enum.TryParse(stringValue?.ToLower(), out enumeratorValue))
                return enumeratorValue;

            return default;
        }

        /// <summary>
        /// Convert a string to its respective Enumerator.
        /// </summary>
        /// <param name="stringValue">String value to find and get the Enum</param>
        /// <param name="defaultValue">Optional - Set default value when not found</param>
        /// <returns>Enum value for the string or default</returns>
        public static T ToEnum<T>(this string stringValue, T defaultValue) where T : struct, IConvertible
            => ToEnum<T>(stringValue) ?? defaultValue;
    }
}
