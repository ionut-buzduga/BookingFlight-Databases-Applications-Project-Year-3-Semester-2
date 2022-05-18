using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.Abstractions.Repository
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Booking FindUser(Guid flightId,String userMail);
        Booking FindEmail(string userEmail);
    }
}
