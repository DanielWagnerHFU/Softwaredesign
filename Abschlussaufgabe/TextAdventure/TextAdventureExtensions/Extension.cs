using System;

namespace TextAdventureCharacter
{
    public static class Extension
    {
        public static string TrimStart(this string source, string value, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (source.IndexOf(value, 0, comparisonType) == 0)
            {
                return source.Substring(value.Length);
            }
            return source.Substring(0);
        }
    }
}