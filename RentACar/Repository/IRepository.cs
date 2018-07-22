using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
   public interface IRepository<T>
    {
        IEnumerable<T> List();
        void Insert(T item);
        void Update(T item);
        void Delete(object id);
        void Save();
        T SelectById(int id);
    }
}
