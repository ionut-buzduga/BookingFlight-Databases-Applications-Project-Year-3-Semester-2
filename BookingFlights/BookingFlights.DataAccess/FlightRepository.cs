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
    public class FlightRepository : BaseRepository<Flight>, IFlightsRepository
    {
        public FlightRepository(BookingFlightsDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Flight> SearchFlight(string departureCity, string arrivalCity, DateTime departureDate)
        {
            return dbContext.Flights.Where(flight => flight.DepartureCity == departureCity)
                                                 .Where(flight => flight.ArrivalCity == arrivalCity)
                                                 .Where(flight => flight.departureDate.Date == departureDate.Date);
        }
    }
}
