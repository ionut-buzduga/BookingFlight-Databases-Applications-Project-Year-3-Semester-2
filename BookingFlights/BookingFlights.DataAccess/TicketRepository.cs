using BookingFlights.DataModel;
using BookingFlights.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BookingFlights.DataAccess
{
    public class TicketRepository : ITicketRepository
    {
        protected readonly BookingFlightsDbContext dbContext;

        public TicketRepository(BookingFlightsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Ticket Add(Ticket element)
        {
            var returnEntity = dbContext.Set<Ticket>().Add(element)
                                     .Entity;

            return returnEntity;
        }

        public virtual IQueryable<Ticket> FindByCondition(Expression<Func<Ticket, bool>> expression)
        {
            return this.dbContext.Set<Ticket>().Where(expression).AsNoTracking();
        }

        public void Delete(Ticket entity)
        {
            this.dbContext.Set<Ticket>().Remove(entity);
        }

        public virtual IQueryable<Ticket> GetAll()
        {
            return dbContext.Set<Ticket>().AsNoTracking();
        }

        public Ticket GetById(Guid id)
        {
            return dbContext.Set<Ticket>().Single(entity => entity.Id == id);
        }

        public Ticket ChooseTicket1(Ticket element)
        {
            
            var returnEntity = dbContext.Set<Ticket>().Update(element).Entity;

            return returnEntity;

        }

        public Ticket Update(Ticket element)
        {
            //  throw new NotImplementedException();
            var returnEntity = dbContext.Set<Ticket>().Update(element).Entity;

            return returnEntity;

        }

        public async Task SaveAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
