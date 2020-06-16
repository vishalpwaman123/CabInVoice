using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
    public class cabInVoiceGenerator
    {
        private static readonly int minimumCostPerKiloMeter = 10;
        private static readonly int costPerTime = 1;
        private static readonly double minimumFare = 5;

        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * minimumCostPerKiloMeter + time * costPerTime;
            
            return Math.Max(totalFare, minimumFare); 
        }

        public double CalculateMultipleFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }

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
