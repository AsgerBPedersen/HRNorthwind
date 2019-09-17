using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities.Models;

namespace Northwind.DataAcess
{
    public class OrderService : IOrderService
    {
        public Task<int> AddOrder(Order employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrder(Order employee)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateOrder(Order employee)
        {
            throw new NotImplementedException();
        }
    }
}
