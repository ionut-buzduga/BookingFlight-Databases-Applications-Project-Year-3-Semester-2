using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataModel
{
    public class Passenger
    {
        public Passenger()
        {
            this.Flights = new HashSet<Flight>();  
        }

        public Guid PassengerId { get; set; }

        public string PassengerName { get; set; }

        public string PassengerSurname { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public ICollection<Ticket> Ticket { get; set; }

        public ICollection<Flight> Flights { get; set; } 
    }
}
