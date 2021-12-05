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
        protected DbContext context;
        private readonly DbSet<T> dbSet;


        public RepositoryGeneric(DbContext dbContextType)
        {
            context = dbContextType;
            dbSet = context.Set<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var query = dbSet.AsQueryable();
            foreach (var include in new T().IncludesNeeded())
            {
                query = query.Include(include);
            }
            if (predicate == null)
            {
                return query.ToList();
            }
            query = query.Where(predicate).AsQueryable();
            return query.ToList();
        }

        public T Get(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null) return dbSet.AsQueryable().FirstOrDefault();
            var query = dbSet.Where(predicate).AsQueryable();
            foreach (var include in new T().IncludesNeeded())
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault();
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

    }
}
