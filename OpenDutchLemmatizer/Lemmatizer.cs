using System;

namespace OpenDutchLemmatizer
{
    public class Lemmatizer
    {
        public string GetLemma(string word)
        {
            if (word == null)
                return "";

            var result = word;

            if (result.EndsWith("en", StringComparison.Ordinal))
            {
                result = result.Substring(0, result.Length - 2);
                
                if (CharUtils.EndsWithDoubleConsonant(result))
                {
                    result = result.Substring(0, result.Length - 1);
                }
            }

            if (result.EndsWith("dt", StringComparison.Ordinal))
                result = result.Substring(0, result.Length - 1);

            if (result.EndsWith("tje", StringComparison.Ordinal))
                result = result.Substring(0, result.Length - 3);

            if (result.EndsWith("tjes", StringComparison.Ordinal))
                result = result.Substring(0, result.Length - 4);

            return result.ToLower();
        }

    }
}
