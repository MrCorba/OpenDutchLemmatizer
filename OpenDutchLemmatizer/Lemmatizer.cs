using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                result = result.Substring(0, result.Length - 2);
            
            if (result.EndsWith("dt", StringComparison.Ordinal))
                result = result.Substring(0, result.Length - 1);
            
            return result;
        }

    }
}
