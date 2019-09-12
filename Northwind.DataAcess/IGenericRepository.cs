using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcess
{
    public interface IGenericRepository<T>
    {
        Task<T> GetById(int id);

        Task<T> GetById(int id, string children);
        Task<IList<T>> List();
        Task<IList<T>> List(string children);
        Task<IList<T>> List(Expression<Func<T, bool>> predicate);
        Task<IList<T>> List(Expression<Func<T, bool>> filter, string children);
        Task<int> Add(T entity);
        Task<int> Delete(T entity);
        Task<int> Edit(T entity);
        Task<int> DeleteRange(IEnumerable<T> Entities);
    }

}
