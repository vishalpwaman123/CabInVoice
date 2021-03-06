using NUnit.Framework;
using CabInVoice;
using System.Collections.Generic;

namespace CabinVoiceTest
{
    public class Tests
    {
        InvoiceService invoiceService = null;
        [SetUp]
        public void SetUp()
        {
            invoiceService = new InvoiceService();
        }

        /// <summary>
        /// Given Distance And Time When Passing Arragment Should Return Total Fare
        /// </summary>
        [Test]
        public void givenDistanceAndTime_WhenPassingArragment_ShouldReturnTotalFare()
        {
            try
            {
                cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
                double distance = 2.0;
                int time = 5;
                double fare = invoiceGenerator.CalculateFare(distance, time);
                Assert.AreEqual(25, fare);
            }catch(CabInvoiceAnalyserException e)
            {
                Assert.AreEqual(CabInvoiceAnalyserException.ExceptionType.INVALID_ARGUMENT_EXCEPTION, e.type);
            }
        }

        /// <summary>
        /// Given Distance And Time When Passing Integer Arragment Should Throw Exception
        /// </summary>
        [Test]
        public void givenDistanceAndTime_WhenPassingIntegerArragment_ShouldThrowException()
        {
            try
            {
                cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
                double fare = invoiceGenerator.CalculateFare(0.0, 0);
            }
            catch (CabInvoiceAnalyserException e)
            {
                Assert.AreEqual(CabInvoiceAnalyserException.ExceptionType.INVALID_ARGUMENT_EXCEPTION, e.type);
            }
        }

        /// <summary>
        /// Given Less Distance And Time when Passing Argument Should Return Minimum Fare
        /// </summary>
        [Test]
        public void givenLessDistanceAndTime_whenPassingArgument_shouldReturnMinimumFare()
        {
            try
            {
                cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
                double distance = 0.1;
                int time = 1;
                double fare = invoiceGenerator.CalculateFare(distance, time);
                Assert.AreEqual(5, fare);
            }
            catch (CabInvoiceAnalyserException e)
            {
                Assert.AreEqual(CabInvoiceAnalyserException.ExceptionType.INVALID_ARGUMENT_EXCEPTION, e.type);
            }
        }

        /// <summary>
        /// Given Multiple Distance And Time when Passing Argument should Return Aggregate Fare
        /// </summary>
        [Test]
        public void givenMultipleDistanceAndTime_whenPassingArgument_shouldReturnAggregateFare()
        {
            try
            {
                cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
                Ride[] rides = { new Ride(2.0,5),
                            new Ride(0.1, 1)
                            };
                double fare = invoiceGenerator.CalculateMultipleFare(rides);
                Assert.AreEqual(30, fare);
            }
            catch (CabInvoiceAnalyserException e)
            {
                Assert.AreEqual(CabInvoiceAnalyserException.ExceptionType.INVALID_ARGUMENT_EXCEPTION, e.type);
            }
        }

        /// <summary>
        /// Given Multiple Distance And Time when Passing Null Argument should Return Aggregate Fare
        /// </summary>
        [Test]
        public void givenMultipleDistanceAndTime_whenPassingNullArgument_shouldReturnAggregateFare()
        {
            try
            {
                cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
                Ride[] rides = null;
                double fare = invoiceGenerator.CalculateMultipleFare(rides);
            }
            catch (CabInvoiceAnalyserException e)
            {
                Assert.AreEqual(CabInvoiceAnalyserException.ExceptionType.NULL_REFERENCE_EXCEPTION, e.type);
            }
        }

        /// <summary>
        /// Given Multiple Rides when Passing Argument Should Return Invoice Summary
        /// </summary>
        [Test]
        public void GivenMultipleRides_whenPassingArgument_ShouldReturnInvoiceSummary()
        {
            try
            {
                cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
                Ride[] rides = { new Ride(2.0,5),
                            new Ride(0.1, 1)
                            };
                InvoiceSummary summary = invoiceGenerator.CalculateMultipleFareUsingSummery(rides);
                InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
                Assert.AreEqual(expectedInvoiceSummary, summary);
            }
            catch (CabInvoiceAnalyserException e)
            {
                Assert.AreEqual(CabInvoiceAnalyserException.ExceptionType.INVALID_ARGUMENT_EXCEPTION, e.type);
            }
        }

        /// <summary>
        /// Given UserId and Rides When Calculated should return invoice summary
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_WhenCalculated_shouldReturnInvoiceSummary()
        {
            try
            {
                string userId = "abc@g.com";
                Ride[] rides = {
                             new Ride(2.0, 5),
                             new Ride(0.1, 1)
                                };
                invoiceService.AddRides(userId, rides);
                InvoiceSummary summary = invoiceService.GetInvoiceSummary(userId);
                InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
                Assert.AreEqual(expectedInvoiceSummary, summary);
            }
            catch (CabInvoiceAnalyserException e)
            {
                Assert.AreEqual(CabInvoiceAnalyserException.ExceptionType.INVALID_ARGUMENT_EXCEPTION, e.type);
            }
        }

        /// <summary>
        /// Given Multiple Rides When Passing Wrong Argument Should Return Invoice Summary
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenPassingWrongArgument_ShouldReturnInvoiceSummary()
        {
            try
            {
                cabInVoiceGenerator invoiceGenerator = new cabInVoiceGenerator();
                Ride[] rides = { new Ride(0,0),
                            new Ride(0,0)
                            };
                InvoiceSummary summary = invoiceGenerator.CalculateMultipleFareUsingSummery(rides);
            }
            catch (CabInvoiceAnalyserException e)
            {
                Assert.AreEqual(CabInvoiceAnalyserException.ExceptionType.INVALID_ARGUMENT_EXCEPTION, e.type);
            }
        }

        /// <summary>
        /// Given Normal And Premium Rides When Calculated should Return Invoice Summary
        /// </summary>
        [Test]
        public void GivenNormalAndPremiumRides_WhenCalculated_shouldReturnInvoiceSummary()
        {
            try
            {
                PremiumRide[] premiumRides = {
                            new PremiumRide(2.0, 5),
                            new PremiumRide(0.1, 1)
                        };
                InvoiceSummary premiumRideSummary = invoiceService.PremiumCalculateFare(premiumRides);
                InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 40.0);
                Assert.AreEqual(expectedInvoiceSummary, premiumRideSummary);
            }
            catch (CabInvoiceAnalyserException e)
            {
                Assert.AreEqual(CabInvoiceAnalyserException.ExceptionType.INVALID_ARGUMENT_EXCEPTION, e.type);
            }
        }
    }
}