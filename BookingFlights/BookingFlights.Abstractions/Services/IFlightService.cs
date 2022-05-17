using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.Abstractions.Services
{
    public interface IFlightService
    {
        // IQueryable<Flight> GetAllQueryable();
        // IQueryable<Flight> GetByCondition(Expression<Func<Course, bool>> expression);
        IQueryable<Flight> GetAllQueryable();
        void CreateFromEntity(Flight flight);
        public void UpdateFromEntity(Flight flight);

        public void DeleteFromEntity(Flight flight);

        System.Threading.Tasks.Task SaveAsync();
        //  void FlightFromEntity(Flight flight);
        //  void DeleteFromEntity(Flight flight);
        //  System.Threading.Tasks.Task SaveAsync();
        //  IQueryable<Flight> GetFlights();

    }
}
