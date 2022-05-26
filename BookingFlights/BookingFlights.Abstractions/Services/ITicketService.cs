using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.Abstractions.Services
{
    public interface ITicketService
    {
        IQueryable<Ticket> GetAllQueryable();
        void CreateFromEntity(Ticket passenger);
        public void UpdateFromEntity(Ticket passenger);

        public void ChooseTicket1(Ticket passenger);
        public void DeleteFromEntity(Ticket passenger);

        void TicketForFLight(Ticket ticket);
        System.Threading.Tasks.Task SaveAsync();
        IQueryable<Ticket> findSpecificFlight(Guid id);

        IQueryable<Ticket> GetByCondition(Expression<Func<Ticket, bool>> expression);
    }
}
