using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.Abstractions.Services
{
    public interface IPassengerService
    {
       
        IQueryable<Passenger> GetAllQueryable();
        void CreateFromEntity(Passenger passenger);
        public void UpdateFromEntity(Passenger passenger);

        public void DeleteFromEntity(Passenger passenger);

        System.Threading.Tasks.Task SaveAsync();
       

    }
}
