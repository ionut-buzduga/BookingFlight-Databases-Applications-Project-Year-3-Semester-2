using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataModel
{
    public class Passenger: EntityClass
    {
        public Passenger()
        {
            this.Flights = new HashSet<Flight>();  
        }

        public string PassengerName { get; set; }

        public string PassengerSurname { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public Seat Seat { get; set; }

        [Required]
        public ICollection<Flight> Flights { get; set; } 
    }
}
