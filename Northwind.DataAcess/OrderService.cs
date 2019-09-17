using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Models;

namespace Northwind.DataAcess
{
    public class OrderService : IOrderService
    {
        private readonly NorthwindContext context = new NorthwindContext();
        private IGenericRepository<Order> _orders;
        private IGenericRepository<OrderDetail> _orderDetails;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Shipper> _shippers;
        #region properties
        //instantiates a new repository if there isn't one already.
        public IGenericRepository<Order> Orders
        {
            get
            {

                if (this._orders == null)
                {
                    this._orders = new GenericRepository<Order>(context);
                }
                return _orders;
            }
        }

        public IGenericRepository<Customer> Customers
        {
            get
            {

                if (this._customers == null)
                {
                    this._customers = new GenericRepository<Customer>(context);
                }
                return _customers;
            }
        }

        public IGenericRepository<Shipper> Shippers
        {
            get
            {

                if (this._shippers == null)
                {
                    this._shippers = new GenericRepository<Shipper>(context);
                }
                return _shippers;
            }
        }
        public IGenericRepository<OrderDetail> OrderDetails
        {
            get
            {

                if (this._orderDetails == null)
                {
                    this._orderDetails = new GenericRepository<OrderDetail>(context);
                }
                return _orderDetails;
            }
        }
        #endregion
        public async Task<int> AddOrder(Order order)
        {
            return await Orders.Add(order);
        }

        public async Task DeleteOrder(Order order)
        {
            var orderDetails = await OrderDetails.List(o => o.OrderId == order.Id);

            await OrderDetails.DeleteRange(orderDetails);
            await Orders.Delete(order);
        }

        public async Task<Order> GetById(int id)
        {
            return await Orders.GetById(id, new string[3] { "Employee", "Customer", "ShipViaNavigation" });
        }

        public async Task<IList<Customer>> GetCustomers()
        {
            return await Customers.List();
        }

        public async Task<IList<Order>> GetNextShipments()
        {
            IList<Order> list = await Orders.List(new string[3] { "Employee", "Customer", "ShipViaNavigation" });
            return list.Cast<Order>().Where(o => o.ShippedDate == null).OrderBy(d => d.RequiredDate).Take(25).ToList();
        }

        public async Task<IList<Order>> GetOrders()
        {
            
            return await Orders.List(new string[3] {"Employee","Customer","ShipViaNavigation"});
        }

        public async Task<IList<Shipper>> GetShippers()
        {
            return await Shippers.List();
        }

        public async Task<int> UpdateOrder(Order order)
        {
            return await Orders.Edit(order);
        }
    }
}
