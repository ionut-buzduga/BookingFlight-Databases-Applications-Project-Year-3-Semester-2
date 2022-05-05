using BookingFlights.Abstractions.Repository;
using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataAccess
{
    public class PassengerRepository : BaseRepository<Passenger>, IPassengersRepository
    {
        public PassengerRepository(BookingFlightsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
