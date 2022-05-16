using BookingFlights.Abstractions.Repository;
using BookingFlights.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BookingFlights.DataAccess
{
    public class FlightRepository : BaseRepository<Flight>, IFlightsRepository
    {
        public FlightRepository(BookingFlightsDbContext dbContext) : base(dbContext)
        {
        }
        public override IQueryable<Flight> FindAll()
        {
            return base.FindAll().Include(x => x.Name);
        }
        public override IQueryable<Flight> FindByCondition(Expression<Func<Flight, bool>> expression)
        {
            return base.FindAll().Include(x => x.Name).Where(expression).AsNoTracking();
        }
        //public override IQueryable<Flight> GetAll()
        //{
        //    return dbContext.Set<Flight>()
        //                    .Include(flight => flight.Seats)
        //                    .ToList();
        //}
    }
}
