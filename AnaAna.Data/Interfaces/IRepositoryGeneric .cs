using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Data.Interfaces
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> FilterByAsync(); 
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> AddAsync(T obj);
        
        T Update(T obj);
        void Delete(T obj);

    }
}
