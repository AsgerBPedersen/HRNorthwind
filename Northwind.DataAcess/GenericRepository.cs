using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityWithId
    {
        private readonly NorthwindContext _dbContext;

        public GenericRepository(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetById(int id, string children)
        {
            return await Task.Run(() => _dbContext.Set<T>().Include(children).AsEnumerable().SingleOrDefault(e => e.Id == id));
        }
        public async Task<IList<T>> List()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }



        public virtual async Task<IList<T>> List(string children)
        {
            return await _dbContext.Set<T>().Include(children).ToListAsync();    
        }
        public async Task<IList<T>> List(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                   .Where(predicate)
                   .ToListAsync();
        }

        public async Task<IList<T>> List(Expression<Func<T, bool>> filter, string children)
        {

            return await _dbContext.Set<T>().Include(children).Where(filter).ToListAsync();

        }
        public async Task<int> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Edit(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteRange(IEnumerable<T> Entities)
        {
            _dbContext.Set<T>().RemoveRange(Entities);
            return await _dbContext.SaveChangesAsync();
        }

        
    }
}
