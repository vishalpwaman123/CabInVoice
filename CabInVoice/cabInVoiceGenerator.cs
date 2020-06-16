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
            if (totalFare < minimumFare)
            {
                return minimumFare;
            }
            return totalFare;
        }
    }
}
