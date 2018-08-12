using System;

namespace OpenDutchLemmatizer
{
    public class Lemmatizer
    {
        public string GetLemma(string word)
        {
            if (word == null)
                return "";

            var result = word.ToLower();
            CleanUp(result);

            if (result.EndsWith("en", StringComparison.Ordinal))
            {
                if (result.EndsWith("den", StringComparison.Ordinal))
                {
                    result = result.Substring(0, result.Length - 3);
                    result += "en";
                }
                else
                {
                    result = result.Substring(0, result.Length - 2);
                    result = CleanUp(result);
                }
            }

            if (result.EndsWith("dt", StringComparison.Ordinal))
            {
                result = result.Substring(0, result.Length - 1);
                result = CleanUp(result);
            }

            if (result.EndsWith("tje", StringComparison.Ordinal))
            {
                result = result.Substring(0, result.Length - 3);
                result = CleanUp(result);
            }

            if (result.EndsWith("tjes", StringComparison.Ordinal))
            {
                result = result.Substring(0, result.Length - 4);
                result = CleanUp(result);
            }

            if (result.EndsWith("pje", StringComparison.Ordinal))
            {
                result = result.Substring(0, result.Length - 2);
                result = CleanUp(result);
            }

            if (result.EndsWith("s", StringComparison.Ordinal))
            {
                result = result.Substring(0, result.Length - 1);
                result = CleanUp(result);
            }

            return result.ToLower();
        }

        private string CleanUp(string word)
        {
            word = CharUtils.UnDoubleConsonant(word);
            word = CharUtils.ChangeMultiConsonantToSingle(word);

            return word;
        }

    }
}
