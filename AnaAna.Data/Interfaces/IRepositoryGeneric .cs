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
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<List<T>> FilterByAsync(); 
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> AddAsync(T obj);
        
        Task<T> UpdateAsync(T obj);
        Task DeleteAsync(T obj);

        Task<int> CountByProperty(Expression<Func<T, bool>> predicate);

    }
}
