using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDutchLemmatizer;
using System.IO;
using System.Diagnostics;

namespace OpenDutchLemmatizerTest
{
    [TestClass]
    public class LemmaTest
    {
        [TestMethod]
        public void TestLemmatizer()
        {
            var lemmatizer = new Lemmatizer();

            var dir = Environment.CurrentDirectory;
            var testFile = Path.Combine(dir, "TestData", "dutch_lemmas.txt");
            var testOutput = Path.Combine(dir, "failed_words.txt");
            string line;

            var goodCount = 0;
            var totalCount = 0;

            using (var reader = new StreamReader(testFile))
            using (var writer = new StreamWriter(testOutput))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var words = line.Split(',');

                    if (words[0] == lemmatizer.GetLemma(words[1]))
                        goodCount++;
                    else
                        writer.WriteLine(String.Join(",", words));

                    totalCount++;
                }
            }

            Assert.AreEqual(totalCount, goodCount);
        }
    }
}
