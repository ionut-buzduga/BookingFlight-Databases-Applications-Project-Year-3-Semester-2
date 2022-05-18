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
        public string PassengerName { get; set; }

        public string PassengerSurname { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }
    }
}
