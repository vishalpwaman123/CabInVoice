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

        public double CalculateMultipleFare()
        {
            double totalFare = 0;
            totalFare = CalculateFare(2.0, 5);
            totalFare = totalFare + CalculateFare(0.1, 1);
            return totalFare;
        }

    }
}
