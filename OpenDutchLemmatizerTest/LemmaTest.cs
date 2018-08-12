using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDutchLemmatizer;
using System;
using System.IO;

namespace OpenDutchLemmatizerTest
{
    [TestClass]
    public class LemmaTest
    {
        public TestContext TestContext { get; set; }
        public Lemmatizer Lemmatizer;

        public LemmaTest()
        {
            Lemmatizer = new Lemmatizer();
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestData\\dutch_lemmas.csv", "dutch_lemmas#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestLemmatizer()
        {
            var lemma = TestContext.DataRow.ItemArray[0].ToString();
            var form = TestContext.DataRow.ItemArray[1].ToString();
            Assert.AreEqual(lemma, Lemmatizer.GetLemma(form));
        }

        [TestMethod]
        public void TestCountLemmatizer()
        {
            var dir = Environment.CurrentDirectory;
            var testFile = Path.Combine(dir, "TestData", "dutch_lemmas.csv");
            string line;

            var goodCount = 0;
            var totalCount = 0;

            using (var reader = new StreamReader(testFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var words = line.Split(',');

                    if (words[0] == Lemmatizer.GetLemma(words[1]))
                        goodCount++;

                    totalCount++;
                }
            }

            Assert.AreEqual(totalCount, goodCount);
        }
    }
}
