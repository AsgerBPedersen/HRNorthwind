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
        T GetById(int id);

        T GetById(int id, string children);
        Task<IEnumerable<T>> List();
        IEnumerable<T> List(string children);
        Task<IList<T>> List(Expression<Func<T, bool>> predicate);
        Task<IList<T>> List(Expression<Func<T, bool>> filter, string children);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void DeleteRange(IEnumerable<T> Entities);
    }

}
