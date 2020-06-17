using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
    public class PremiumRide
    {
        //Declare Global Variable
        public double distance;
        public int time;

        //Assign value to current distance and time
        public PremiumRide(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
