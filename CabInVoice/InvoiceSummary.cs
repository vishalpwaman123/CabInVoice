using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
   public class InvoiceSummary
    {
        //Declare Variable for InvoiceSummery
        public int numberOfRides;
        public double totalFare;
        public double averageFare;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfRides"></param>
        /// <param name="totalFare"></param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        override
        public bool Equals(Object o)
        {
            if (this == o) return true;
            if (o == null || !this.GetType().Equals(o.GetType())) return false;
            InvoiceSummary that = (InvoiceSummary)o;
            return numberOfRides == that.numberOfRides &&
                totalFare.CompareTo(that.totalFare) == 0 &&
                averageFare.CompareTo(that.averageFare) == 0;
        }

    }
}
