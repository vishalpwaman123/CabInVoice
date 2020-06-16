using NUnit.Framework;
using CabInVoice;
using System.Collections.Generic;

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

        [Test]
        public void givenMultipleDistanceAndTime_whenPassingArgument_shouldReturnAggregateFare()
        {
            cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
            Ride[] rides = { new Ride(2.0,5),
                            new Ride(0.1, 1)
                            };
            double fare = invoiceGenerator.CalculateMultipleFare(rides);
            Assert.AreEqual(30, fare);
        }

        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
            Ride[] rides = { new Ride(2.0,5),
                            new Ride(0.1, 1)
                            };
            InvoiceSummary summary = invoiceGenerator.CalculateMultipleFareUsingSummery(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}