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
        /// Assign Value to Current distance and time
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride(double distance, int time)
        {
            if (distance == 0.0 || time == 0)
                throw new CabInvoiceAnalyserException("Invalid Argument", CabInvoiceAnalyserException.ExceptionType.INVALID_ARGUMENT_EXCEPTION); 
            this.distance = distance;
            this.time = time;
        }
    }
}
