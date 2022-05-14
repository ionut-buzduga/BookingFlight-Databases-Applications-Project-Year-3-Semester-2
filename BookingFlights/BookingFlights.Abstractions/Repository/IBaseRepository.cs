using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.Abstractions.Repository
{
    public interface IBaseRepository<T>
    {

        T GetById(Guid id);

        IQueryable<T> GetAll();

        T Add(T element);

        void Delete(T entity);

        T Update(T element);

        Task SaveAsync();

    }
}
