using BookingFlights.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.DataAccess
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        public T Add(T element)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public T Update(T elementToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
