using System;

namespace OpenDutchLemmatizer
{
    public class Lemmatizer
    {
        public string GetLemma(string word)
        {
            if (word == null)
                return string.Empty;

            var result = word.ToLower();
            CleanUp(result);

            if (result.EndsWithOrdinal("en"))
            {
                if (result.EndsWithOrdinal("den"))
                {
                    result = result.RemoveLast(3);
                    result += "en";
                }
                else
                {
                    result = result.RemoveLast(2);
                    result = CleanUp(result);
                }
            }
            else

            if (result.EndsWithOrdinal("dt"))
            {
                result = result.RemoveLast(2);
                result = CleanUp(result);
            }

            else if (result.EndsWithOrdinal("tje"))
            {
                result = result.RemoveLast(3);
                result = CleanUp(result);
            }

            else if (result.EndsWithOrdinal("tjes"))
            {
                result = result.RemoveLast(4);
                result = CleanUp(result);
            }

            else if (result.EndsWithOrdinal("pje"))
            {
                result = result.RemoveLast(2);
                result = CleanUp(result);
            }

            else if (result.EndsWithOrdinal("s"))
            {
                result = result.RemoveLast(1);
                result = CleanUp(result);
            }

            else if (result.EndsWithOrdinal("nd"))
            {
                result = result.RemoveLast(1);
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
