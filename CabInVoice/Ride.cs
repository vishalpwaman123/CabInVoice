using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
   public class Ride
    {
        //Declare Variable for CabinVoice
        public double distance;
        public int time;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }

    }
}
