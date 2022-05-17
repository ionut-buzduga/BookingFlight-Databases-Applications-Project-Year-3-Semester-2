using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.Abstractions.Repository
{
    public interface IBaseRepository<T>
    {

        T GetById(Guid id);

        IQueryable<T> GetAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        T Add(T element);

        void Delete(T entity);

        T Update(T element);

        Task SaveAsync();

    }
}
