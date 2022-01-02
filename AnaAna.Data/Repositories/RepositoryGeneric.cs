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
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class, IIncludeObject, new()
    {
        protected ApplicationDbContext context;
        protected readonly DbSet<T> dbSet;


        public RepositoryGeneric(ApplicationDbContext dbContextType)
        {
            context = dbContextType;
            dbSet = context.Set<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            var query = dbSet.AsQueryable();
            foreach (var include in new T().IncludesNeeded())
            {
                query = query.Include(include);
            }
            //if (predicate == null)
            //{
            //    return  query.ToListAsync();
            //}
            //query = query.Where(predicate).AsQueryable();
            return query.ToListAsync();
        }

        //public Task<List<T>> FilterByAsync()
        //{
        //    var query = dbSet.AsQueryable<T>();
            

        //}

        public async Task<T> GetAsync(Expression<Func<T,bool>> predicate = null)
        {
            if (predicate == null) return await dbSet.AsQueryable().FirstOrDefaultAsync();
            var query = dbSet.Where(predicate).AsQueryable();
            foreach (var include in new T().IncludesNeeded())
            { 
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T obj)
        {
            context.Attach(obj);
            await dbSet.AddAsync(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public T Update(T obj)
        {
            context.Attach(obj);
            dbSet.Update(obj);
            context.SaveChanges();
            return obj;
        }

        public void Delete(T obj)
        {
            context.Attach(obj);
            dbSet.Remove(obj);
            context.SaveChanges();
        }

        public Task<List<T>> FilterByAsync()
        {
            throw new NotImplementedException();
        }


    }
}
