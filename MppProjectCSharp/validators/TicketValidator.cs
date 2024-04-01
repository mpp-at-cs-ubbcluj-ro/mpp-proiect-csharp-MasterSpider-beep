using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaC.domain;

namespace MppProjectCSharp.validators
{
    internal class TicketValidator
    {
        public bool validate(Ticket ticket)
        {
            if(ticket == null)
            {
                return false;
            }
            if(ticket.NoSeats <= 0)
            {
                return false;
            }
            if(ticket.Tourists.Count <= 0)
            {
                return false;
            }
            if(ticket.Address.Trim().Length == 0)
            {
                return false;
            }
            if(ticket.ClientName.Trim().Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}
