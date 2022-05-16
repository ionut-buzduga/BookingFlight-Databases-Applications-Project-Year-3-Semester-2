using BookingFlights.Abstractions.Repository;
using BookingFlights.Abstractions.Services;
using BookingFlights.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.AppLogic.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PassengerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Passenger> GetAllQueryable()
        {
            return _repositoryWrapper.PassengersRepository.GetAll();
        }


        public void CreateFromEntity(Passenger passenger)
        {
            _repositoryWrapper.PassengersRepository.Add(passenger);

        }

        public void UpdateFromEntity(Passenger passenger)
        {
            _repositoryWrapper.PassengersRepository.Update(passenger);
        }

        public void DeleteFromEntity(Passenger passenger)
        {
            _repositoryWrapper.PassengersRepository.Delete(passenger);
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _repositoryWrapper.PassengersRepository.SaveAsync();
        }

    }
}
