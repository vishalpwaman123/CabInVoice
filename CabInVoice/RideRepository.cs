using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
    public class RideRepository
    {
            Dictionary<string, List<Ride>> userRides = null;

            public RideRepository()
            {
                this.userRides = new Dictionary<string, List<Ride>>();
            }

            public void AddRide(string userId, Ride[] rides)
            {
                if(rides==null)
                {
                throw new CabInvoiceAnalyserException("Invalid Argument", CabInvoiceAnalyserException.ExceptionType.NULL_REFERENCE_EXCEPTION);
                }
                bool rideList = this.userRides.ContainsKey(userId);
                if (rideList == false)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }

            public Ride[] GetRides(string userId)
            {
                return this.userRides[userId].ToArray();
            }

        }
    }
