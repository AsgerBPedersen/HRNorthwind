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
        /// <summary>
        /// Gets or sets Order repository. instantiates a new repository if there isn't one already.
        /// </summary>
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
            set => _orders = value;
        }
        /// <summary>
        /// Gets or sets Customer repository. instantiates a new repository if there isn't one already.
        /// </summary>
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
            set => _customers = value;
        }
        /// <summary>
        /// Gets or sets Shipper repository. instantiates a new repository if there isn't one already.
        /// </summary>
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
            set => _shippers = value;
        }
        /// <summary>
        /// Gets or sets OrderDetails repository. instantiates a new repository if there isn't one already.
        /// </summary>
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
            set => _orderDetails = value;
        }
        #endregion
        /// <summary>
        /// Adds an Order to the database
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<int> AddOrder(Order order)
        {
            return await Orders.Add(order);
        }
        /// <summary>
        /// Deletes an Order from the database
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task DeleteOrder(Order order)
        {
            var orderDetails = await OrderDetails.List(o => o.OrderId == order.Id);

            await OrderDetails.DeleteRange(orderDetails);
            await Orders.Delete(order);
        }
        /// <summary>
        /// Gets an Order by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetById(int id)
        {
            return await Orders.GetById(id, new string[4] { "Employee", "Customer", "ShipViaNavigation", "OrderDetails.Product" });
        }
        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Customer>> GetCustomers()
        {
            return await Customers.List();
        }
        /// <summary>
        /// Gets the next 25 upcomming shipments.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Order>> GetNextShipments()
        {
            IList<Order> list = await Orders.List(new string[3] { "Employee", "Customer", "ShipViaNavigation" });
            return list.Cast<Order>().Where(o => o.ShippedDate == null).OrderBy(d => d.RequiredDate).Take(25).ToList();
        }
        /// <summary>
        /// Gets all Orders
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Order>> GetOrders()
        {
            
            return await Orders.List(new string[3] {"Employee","Customer","ShipViaNavigation"});
        }
        /// <summary>
        /// Gets all Shippers
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Shipper>> GetShippers()
        {
            return await Shippers.List();
        }
        /// <summary>
        /// Updates the Order in the database
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<int> UpdateOrder(Order order)
        {
            return await Orders.Edit(order);
        }
        /// <summary>
        /// Gets the invoices views from the database by the OrderId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IList<Invoice>> GetInvoice(int id)
        {
            return await context.Invoices.Where(i => i.OrderId == id).ToListAsync();
        }
        
    }
}
