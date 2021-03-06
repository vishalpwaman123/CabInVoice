﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
    public class InvoiceService
    {
        //Declare Global Variable
        public const int MinimumCostPerTime = 10;
        public const double CostPerTime = 1;
        public const double MinimumFare = 5;
        public RideRepository rideRepository;
        public const int PremiumCostPerTime = 15;

        public InvoiceService()
        {
            this.rideRepository = new RideRepository();
        }

        /// <summary>
        /// Function for Calculating totalFare 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double CalculateFare(double distance, int time)
        {

            double totalFare = (distance * MinimumCostPerTime) + (time * CostPerTime);
            return Math.Max(totalFare, MinimumFare);

        }

        /// <summary>
        /// Calculate Fare for multiple Rides
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {

            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }

        /// <summary>
        /// Add Rides TO Ride Repository
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId, Ride[] rides)
        {
            rideRepository.AddRide(userId, rides);
        }

        /// <summary>
        /// Given User Id should get from RideRpository Rides.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            if (userId == null)
            {
                throw new CabInvoiceAnalyserException("Invalid Argument", CabInvoiceAnalyserException.ExceptionType.NULL_REFERENCE_EXCEPTION);
            }
            return this.CalculateFare(rideRepository.GetRides(userId));
        }

        /// <summary>
        /// In Function Calculate Total Fare  and return max fare
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double PremiumCalculateFare(double distance, int time)
        {
            if (distance == 0.0)
            {
                throw new CabInvoiceAnalyserException("Invalid Argument", CabInvoiceAnalyserException.ExceptionType.INVALID_ARGUMENT_EXCEPTION);
            }
            double totalFare = (distance * PremiumCostPerTime) + (time * CostPerTime);
            return Math.Max(totalFare, MinimumFare);
        }

        /// <summary>
        /// In calculate total fare Using Invoice Summary
        /// </summary>
        /// <param name="premiumRides"></param>
        /// <returns></returns>
        public InvoiceSummary PremiumCalculateFare(PremiumRide[] premiumRides)
        {
            if (premiumRides == null)
            {
                throw new CabInvoiceAnalyserException("Invalid Argument", CabInvoiceAnalyserException.ExceptionType.NULL_REFERENCE_EXCEPTION);
            }
            double totalFare = 0;
            foreach (PremiumRide ride in premiumRides)
            {
                totalFare += PremiumCalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(premiumRides.Length, totalFare);
        }
    }
}

