using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BookingFlights.Abstractions.Services
{
    public interface IBookingService
    {
        IQueryable<Booking> GetAllQueryable();

        IQueryable<Booking> GetByCondition(Expression<Func<Booking, bool>> expression);
        void CreateFromEntity(Booking booking);
        public void UpdateFromEntity(Booking booking);

        public void DeleteFromEntity(Booking booking);

        System.Threading.Tasks.Task SaveAsync();

        Booking FindUser(Guid FlightId,string userMail);
        Booking FindEmail(string userEmail);
    }
}
