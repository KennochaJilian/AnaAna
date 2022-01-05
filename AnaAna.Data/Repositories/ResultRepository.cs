using AnaAna.Data.Interfaces;
using AnaAna.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Data.Repositories
{
    public interface IResultRepository : IRepositoryGeneric<Result> 
    {
        Task<int> GetDistinctResults(Expression<Func<Result, bool>> predicate);
    }

    public class ResultRepository : RepositoryGeneric<Result> , IResultRepository{

    public ResultRepository(ApplicationDbContext context) : base(context)
    {
    }

        public async Task<int> GetDistinctResults(Expression<Func<Result, bool>> predicate)
        {
            var query = await dbSet.AsQueryable().Where(predicate).Select(x => x.User.Id).Distinct().CountAsync();

            return query;
        }


}
}
