using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
    public class cabInVoiceGenerator
    {
        private static readonly int MinimumCostPerKiloMeter = 10;
        private static readonly int CostPerTime = 1;

        public double CalculateFare(double distance, int time)
        {
            return distance * MinimumCostPerKiloMeter + time * CostPerTime;
        }
    }
}
