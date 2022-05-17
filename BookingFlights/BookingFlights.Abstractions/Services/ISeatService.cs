using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.Abstractions.Services
{
    public interface ISeatService
    {

        IQueryable<Seat> GetAllQueryable();
        //  void CreateFromEntity(Seat seat);
        //  public void UpdateFromEntity(Seat seat);

        IQueryable<Seat> GetByCondition(Expression<Func<Seat, bool>> expression);

        public void DeleteFromEntity(Seat seat);

        System.Threading.Tasks.Task SaveAsync();


    }
}
