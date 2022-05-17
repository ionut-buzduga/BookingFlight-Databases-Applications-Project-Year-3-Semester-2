using BookingFlights.Abstractions.Repository;
using BookingFlights.Abstractions.Services;
using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.AppLogic.Services
{
    public class SeatService : ISeatService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SeatService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Seat> GetAllQueryable()
        {
            return _repositoryWrapper.SeatsRepository.GetAll();
        }


        public IQueryable<Seat> GetByCondition(Expression<Func<Seat, bool>> expression)
        {
            return _repositoryWrapper.SeatsRepository.FindByCondition(expression);
        }

        public void DeleteFromEntity(Seat seat)
        {
            _repositoryWrapper.SeatsRepository.Delete(seat);
        }

        public void CreateFromEntity(Seat seat)
        {
            _repositoryWrapper.SeatsRepository.Add(seat);

        }

        public void UpdateFromEntity(Seat seat)
        {
            _repositoryWrapper.SeatsRepository.Update(seat);
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _repositoryWrapper.SeatsRepository.SaveAsync();
        }

        public void SeatForFLight(Seat seat)
        {
            _repositoryWrapper.SeatsRepository.SeatForFlight(seat);
        }
    }
}
