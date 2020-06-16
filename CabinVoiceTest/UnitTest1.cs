using NUnit.Framework;
using CabInVoice;

namespace CabinVoiceTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(25, fare);
        }
    }
}