using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BookingFlights.Abstractions.Repository
{
    public interface IBaseRepository<T>
    {

        T GetById(Guid id);

        IQueryable<T> GetAll();
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Add(T element);

        void Delete(T entity);

        T Update(T element);

        Task SaveAsync();

    }
}
