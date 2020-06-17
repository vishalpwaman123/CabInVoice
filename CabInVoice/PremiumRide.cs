using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
    public class PremiumRide
    {
        public double distance;
        public int time;

        public PremiumRide(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
