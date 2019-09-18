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

        Task<IList<Order>> GetNextShipments();

        Task<Order> GetById(int id);

        Task<int> AddOrder(Order order);

        Task DeleteOrder(Order order);

        Task<int> UpdateOrder(Order order);

        Task<IList<Customer>> GetCustomers();

        Task<IList<Shipper>> GetShippers();

        Task<IList<Invoice>> GetInvoice(int id);


    }
}
