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
        /// <summary>
        /// Returns entity by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        /// <summary>
        /// Returns entity by id. The navigation properties to be included is specified in the string array.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public virtual async Task<T> GetById(int id, string[] children)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (var child in children)
                query = query.Include(child);
            return await Task.Run(() => query.AsEnumerable().SingleOrDefault(e => e.Id == id));
        }
        /// <summary>
        /// Returns all entities.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> List()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }


        /// <summary>
        /// Returns all entities. The navigation properties to be included is specified in the string array.
        /// </summary>
        /// <param name="children"></param>
        /// <returns></returns>
        public virtual async Task<IList<T>> List(string[] children)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (var child in children)
                query = query.Include(child);
            return await query.ToListAsync();
            
        }
        /// <summary>
        /// Returns all entities based on the predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IList<T>> List(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                   .Where(predicate)
                   .ToListAsync();
        }
        /// <summary>
        /// Returns all entities based on the predicate. The navigation properties to be included is specified in the string array.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public async Task<IList<T>> List(Expression<Func<T, bool>> filter, string[] children)
        {
            var query = _dbContext.Set<T>().Where(filter).AsQueryable();
            foreach (var child in children)
                query = query.Include(child);
            return await query.ToListAsync();

        }
        /// <summary>
        /// Adds the entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return await _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Edits the entity in the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Edit(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes the entity from the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes the range of entities from the database.
        /// </summary>
        /// <param name="Entities"></param>
        /// <returns></returns>
        public async Task<int> DeleteRange(IEnumerable<T> Entities)
        {
            _dbContext.Set<T>().RemoveRange(Entities);
            return await _dbContext.SaveChangesAsync();
        }

        
    }
}
