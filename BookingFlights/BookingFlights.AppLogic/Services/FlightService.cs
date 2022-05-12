using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingFlights.Abstractions.Repository;
using BookingFlights.Abstractions.Services;
using BookingFlights.DataModel;

namespace BookingFlights.AppLogic.Services
{
   public class FlightService: IFlightService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public FlightService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateFromEntity(Flight flight)
        {
             _repositoryWrapper.FlightsRepository.Add(flight);
            
        }


    }
}
