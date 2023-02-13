using Schools.DataStorage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DAL.Interfacies.GenaricInterface
{
    public interface IGenaricReprositry<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        Task Insert(T obj);
        void Update( T obj);
        void Updating(object id, T obj);
        void Delete(object id);
        void Save();
        void SaveAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    }
}
