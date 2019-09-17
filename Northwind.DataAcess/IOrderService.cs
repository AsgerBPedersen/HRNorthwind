using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcess
{
    public interface IOrderService
    {
        Task<IList<Order>> GetOrders();

        Task<Order> GetById(int id);

        Task<int> AddOrder(Order employee);

        Task DeleteOrder(Order employee);

        Task<int> UpdateOrder(Order employee);
    }
}
