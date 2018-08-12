using NUnit.Framework;
using OpenDutchLemmatizer;
using System;
using System.Collections.Generic;
using System.IO;

namespace OpenDutchLemmatizerTest
{
    [TestFixture]
    public class LemmaTest
    {
        public TestContext TestContext { get; set; }
        public Lemmatizer Lemmatizer;

        public LemmaTest()
        {
            Lemmatizer = new Lemmatizer();
        }
        
        [Test, TestCaseSource("GetTestData")]
        public void TestLemmatizer(string lemma, string form)
        {
            Assert.AreEqual(lemma, Lemmatizer.GetLemma(form));
        }

        private static IEnumerable<string[]> GetTestData()
        {
            var dir = Path.GetDirectoryName(new Uri(typeof(LemmaTest).Assembly.CodeBase).LocalPath);
            var testFile = Path.Combine(dir, "TestData", "dutch_lemmas.csv");
            string line;

            using (var reader = new StreamReader(testFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line.Split(',');
                }
            }
        }
    }
}
