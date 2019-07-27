using System;

namespace OpenDutchLemmatizer
{
    static class Extensions
    {
        public static bool EndsWithOrdinal(this string @this, string end)
        {
            return @this.EndsWith(end, StringComparison.Ordinal);
        }

        public static string RemoveLast(this string @this, int numberOfChars)
        {
            return @this.Substring(0, @this.Length - numberOfChars);
        }
    }
}
