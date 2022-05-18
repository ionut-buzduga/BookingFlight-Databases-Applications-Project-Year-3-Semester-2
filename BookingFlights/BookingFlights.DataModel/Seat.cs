using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataModel
{
    public class Seat: EntityClass
    { 
        public int Number { get; set; }

        public bool isAvailable { get; set; }

        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
