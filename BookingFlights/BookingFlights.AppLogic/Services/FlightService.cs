using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingFlights.Abstractions.Repository;
using BookingFlights.Abstractions.Services;
using BookingFlights.DataModel;
using Microsoft.EntityFrameworkCore;

namespace BookingFlights.AppLogic.Services
{
   public class FlightService: IFlightService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public FlightService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

       public IQueryable<Flight> GetAllQueryable()
        {
            return _repositoryWrapper.FlightsRepository.GetAll();
        }


        public void CreateFromEntity(Flight flight)
        {     
             _repositoryWrapper.FlightsRepository.Add(flight);
            
        }

        public void UpdateFromEntity(Flight flight)
        {
            _repositoryWrapper.FlightsRepository.Update(flight);
        }

        public void DeleteFromEntity(Flight flight)
        {
            _repositoryWrapper.FlightsRepository.Delete(flight);
        }


        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _repositoryWrapper.FlightsRepository.SaveAsync();
        }

    }
}
