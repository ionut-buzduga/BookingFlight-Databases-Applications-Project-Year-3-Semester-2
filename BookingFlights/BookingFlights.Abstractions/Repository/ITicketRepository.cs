using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.Abstractions.Repository
{
    public interface ITicketRepository
    {
       Ticket GetById(Guid id);

        IQueryable<Ticket> GetAll();

        IQueryable<Ticket> FindByCondition(Expression<Func<Ticket, bool>> expression);

        Ticket Add(Ticket element);

        void Delete(Ticket entity);

        Ticket ChooseTicket1(Ticket element);

        Ticket Update(Ticket element);

        void TicketForFlight(Ticket ticket);

        Task SaveAsync();
    }
}
