using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BookingFlights.Abstractions.Services
{
    public interface IFlightService
    {
        IQueryable<Flight> Flights();
        IQueryable<Flight> GetAllQueryable();
        IQueryable<Flight> GetByCondition(Expression<Func<Flight, bool>> expression);
        void CreateFromEntity(Flight flight);
        public void UpdateFromEntity(Flight flight);

        public void DeleteFromEntity(Flight flight);
       
        System.Threading.Tasks.Task SaveAsync();
        IEnumerable<object> Where(Func<object, bool> p);
        //  void FlightFromEntity(Flight flight);
        //  void DeleteFromEntity(Flight flight);
        //  System.Threading.Tasks.Task SaveAsync();
        //  IQueryable<Flight> GetFlights();

    }
}
