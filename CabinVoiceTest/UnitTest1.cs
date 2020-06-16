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
        public void givenDistanceAndTime_WhenPassingArragment_ShouldReturnTotalFare()
        {
            cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(25, fare);
        }

        [Test]
        public void givenLessDistanceAndTime_whenPassingArgument_shouldReturnMinimumFare()
        {
            cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
            double distance = 0.1;
            int time = 1;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5, fare);
        }
    }
}