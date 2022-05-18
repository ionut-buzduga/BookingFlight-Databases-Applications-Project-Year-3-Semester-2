using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataModel
{
    public class Ticket: EntityClass
    {
        public string Type { get; set; }

        public int Price { get; set; }

        public Guid FlightId  { get; set; }
    }
}
