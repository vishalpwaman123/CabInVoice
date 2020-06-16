using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
    public class cabInVoiceGenerator
    {
        // Declare variable for fare
        private const int minimumCostPerKiloMeter = 10;
        private const int costPerTime = 1;
        private const double minimumFare = 5;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * minimumCostPerKiloMeter + time * costPerTime;
            
            return Math.Max(totalFare, minimumFare); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public double CalculateMultipleFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary CalculateMultipleFareUsingSummery(Ride[] rides)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(rides.Length, totalFare); 
        }

        

}
}
