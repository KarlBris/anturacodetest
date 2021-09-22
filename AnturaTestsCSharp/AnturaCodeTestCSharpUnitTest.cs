using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnturaCodeTestCSharp;

namespace AnturaTestsCSharp
{
    [TestClass]
    public class AnturaCodeTestCSharpUnitTest
    {
        [TestMethod]
        public void TestCountOccurencesInString()
        {
            Assert.AreEqual(1, OccurrenceCounter.CountOccurrencesInString("antura", "antura"));
            Assert.AreEqual(2, OccurrenceCounter.CountOccurrencesInString("anturantura", "antura"));
            Assert.AreEqual(0, OccurrenceCounter.CountOccurrencesInString("anturAntura", "antura"));
            Assert.AreEqual(0, OccurrenceCounter.CountOccurrencesInString("antur a ntura", "antura"));
            Assert.AreEqual(1, OccurrenceCounter.CountOccurrencesInString("antura ntura", "antura"));
            Assert.AreEqual(0, OccurrenceCounter.CountOccurrencesInString("a", "antura"));
            Assert.AreEqual(2, OccurrenceCounter.CountOccurrencesInString("antura", "a"));
            Assert.AreEqual(0, OccurrenceCounter.CountOccurrencesInString("antura", ""));
        }
    }
}
