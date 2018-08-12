namespace OpenDutchLemmatizer
{
    class CharUtils
    {
        public static readonly string VOWELS = "aeiouAEIOU";

        public static bool EndsWithConsonant(string word)
        {
            return IsConsonant(word, word.Length - 1);
        }

        public static bool EndsWithDoubleConsonant(string word)
        {
            if (IsConsonant(word, word.Length - 1) && IsConsonant(word, word.Length - 2))
                return word[word.Length - 1] == word[word.Length - 2];

            return false;
        }

        public static bool EndsWithVowel(string word)
        {
            return IsVowel(word, word.Length - 1);
        }

        public static bool IsVowel(string word, int index)
        {
            return VOWELS.IndexOf(word[index]) >= 0;
        }

        public static bool IsConsonant(string word, int index)
        {
            return !IsVowel(word, index);
        }

        public static string UnDoubleConsonant(string word)
        {
            if (CharUtils.EndsWithDoubleConsonant(word))
            {
                word = word.Substring(0, word.Length - 1);
            }

            return word;
        }

        public static string ChangeMultiConsonantToSingle(string word)
        {
            switch(word[word.Length -1])
            {
                case 'v':
                    word = ReplaceLastCharWith(word, 'f');
                    break;
                case 'z':
                    word = ReplaceLastCharWith(word, 's');
                    break;
            }

            return word;
        }

        private static string ReplaceLastCharWith(string word, char c)
        {
            word = word.Substring(0, word.Length - 1);
            word += c;
            return word;
        }
    }
}
