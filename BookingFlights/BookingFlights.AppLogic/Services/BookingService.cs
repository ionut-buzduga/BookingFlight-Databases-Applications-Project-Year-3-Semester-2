using BookingFlights.Abstractions.Repository;
using BookingFlights.Abstractions.Services;
using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BookingFlights.AppLogic.Services
{
    public class BookingService : IBookingService 
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BookingService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Booking> GetAllQueryable()
        {
            return _repositoryWrapper.BookingRepository.GetAll();
        }
        public IQueryable<Booking> GetByCondition(Expression<Func<Booking, bool>> expression)
        {
            return _repositoryWrapper.BookingRepository.FindByCondition(expression);
        }

        public void CreateFromEntity(Booking booking)
        {
            _repositoryWrapper.BookingRepository.Add(booking);

        }

        public void UpdateFromEntity(Booking booking)
        {
            _repositoryWrapper.BookingRepository.Update(booking);
        }

        public void DeleteFromEntity(Booking booking)
        {
            _repositoryWrapper.BookingRepository.Delete(booking);
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _repositoryWrapper.TicketRepository.SaveAsync();
        }
    }
}
