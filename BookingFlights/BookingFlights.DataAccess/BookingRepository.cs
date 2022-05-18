using BookingFlights.Abstractions.Repository;
using BookingFlights.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataAccess
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(BookingFlightsDbContext dbContext) : base(dbContext)
        {
        }

        public Booking FindEmail(string userEmail)
        {
            return dbContext.Booking.First(booking => booking.UserName == userEmail);
        }

        public Booking FindUser(Guid flightId,String userMail)
        {
           return dbContext.Booking.First(booking => booking.FlightId == flightId && booking.UserName == userMail);
        }
    }
}
