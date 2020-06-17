using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
    public class RideRepository
    {
            //Assign Null value To Dictionary
            Dictionary<string, List<Ride>> userRides = null;
            
            //Declare Dictionary 
            public RideRepository()
            {
                this.userRides = new Dictionary<string, List<Ride>>();
            }

            /// <summary>
            /// In Function Add UserId and rides To List
            /// </summary>
            /// <param name="userId"></param>
            /// <param name="rides"></param>
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
            
            /// <summary>
            /// Return user Id In form of Array
            /// </summary>
            /// <param name="userId"></param>
            /// <returns></returns>
            public Ride[] GetRides(string userId)
            {
                return this.userRides[userId].ToArray();
            }

        }
    }
