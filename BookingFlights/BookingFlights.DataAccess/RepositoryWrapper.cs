using BookingFlights.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataAccess
{
  public  class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly BookingFlightsDbContext _bookingFLightsDbContext;
        private IFlightsRepository? _flightsRepository;

        public IFlightsRepository FlightsRepository
        {
            get
            {
                if (_flightsRepository == null)
                {
                    _flightsRepository = new FlightRepository(_bookingFLightsDbContext);
                }

                return _flightsRepository;
            }
        }

        public RepositoryWrapper(BookingFlightsDbContext bookingFlightsDbContext)
        {
            _bookingFLightsDbContext = bookingFlightsDbContext;
        }

        public void Save()
        {
            _bookingFLightsDbContext.SaveChanges();
        }
    }
}
