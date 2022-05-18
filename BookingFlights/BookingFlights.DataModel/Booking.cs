using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataModel
{
    public class Booking: EntityClass
    {

        public Guid FlightId { get; set; }

        public Guid TicketId { get; set; }  
    }
}
