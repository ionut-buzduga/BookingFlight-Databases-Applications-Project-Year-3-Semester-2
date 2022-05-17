using BookingFlights.Abstractions.Repository;
using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataAccess
{
    public class SeatRepository : BaseRepository<Seat>, ISeatsRepository
    {
        public SeatRepository(BookingFlightsDbContext dbContext) : base(dbContext)
        {
        }

    }
}
