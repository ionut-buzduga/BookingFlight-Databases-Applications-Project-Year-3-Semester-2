using BookingFlights.Abstractions.Repository;
using BookingFlights.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataAccess
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityClass
    {
        protected readonly BookingFlightsDbContext dbContext;

        public BaseRepository(BookingFlightsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Add(T element)
        {
           var returnEntity = dbContext.Set<T>().Add(element)
                                    .Entity;

            return returnEntity;
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.dbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Delete(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }
        //public void Delete(Guid id)
        //{
        //    var item = GetById(id);

        //    dbContext.Set<T>().Remove(item);

        //    dbContext.SaveChanges();
        //}

        public virtual IQueryable<T> GetAll()
        {
            return dbContext.Set<T>().AsNoTracking();
        }

        public T GetById(Guid id)
        {
          return  dbContext.Set<T>().Single(entity => entity.Id == id);
        }

        public T Update(T element)
        {
            //  throw new NotImplementedException();
            var returnEntity = dbContext.Set<T>().Update(element).Entity;

            return returnEntity;

        }

        public async Task SaveAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
