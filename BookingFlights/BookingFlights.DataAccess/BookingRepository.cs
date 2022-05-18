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
    }
}
