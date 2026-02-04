using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineRecording.Data.Repositories.Interfaces
{
    //Generic Repository Interface for base entity CRUD
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Insert(T item);
        void Delete(T item);
        T? GetSingle<TKey>(TKey itemId);
        void Update(T item);
    }
}
