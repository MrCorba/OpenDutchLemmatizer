using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDutchLemmatizer;

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
    }
}
