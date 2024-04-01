using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaC.domain;

namespace MppProjectCSharp.validators
{
    internal class FlightValidator
    {
        public bool validate(Flight flight)
        {
            if (flight == null)
            {
                return false;
            }
            if(flight.AvailableSeats < 0)
            {
                return false;
            }
            if (flight.Airport.Trim().Length == 0)
            {
                return false;
            }
            if(flight.Destination.Trim().Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}
