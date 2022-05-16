using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingFlights.Abstractions.Repository;
using BookingFlights.Abstractions.Services;
using BookingFlights.DataModel;
using System.Linq.Expressions;

namespace BookingFlights.AppLogic.Services
{
   public class FlightService: IFlightService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public IQueryable<Flight> Flights()
        {
            return _repositoryWrapper.FlightsRepository.FindAll();
        }

        public FlightService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

       public IQueryable<Flight> GetAllQueryable()
        {
            return _repositoryWrapper.FlightsRepository.GetAll();
        }

        public IQueryable<Flight> GetByCondition(Expression<Func<Flight, bool>> expression)
        {
            return _repositoryWrapper.FlightsRepository.FindByCondition(expression);
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

        public IEnumerable<object> Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
