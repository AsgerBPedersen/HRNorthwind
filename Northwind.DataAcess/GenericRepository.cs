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

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual T GetById(int id, string children)
        {
            return _dbContext.Set<T>().Include(children).SingleOrDefault(t => t.Id == id);
        }
        public async Task<IEnumerable<T>> List()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }



        public virtual IEnumerable<T> List(string children)
        {

            return _dbContext.Set<T>().Include(children);

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
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> Entities)
        {
            _dbContext.Set<T>().RemoveRange(Entities);
            _dbContext.SaveChanges();
        }

        
    }
}
