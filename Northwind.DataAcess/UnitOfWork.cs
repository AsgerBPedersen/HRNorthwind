using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAcess
{
    public class UnitOfWork : IDisposable
    {
        private NorthwindContext context = new NorthwindContext();
        private IGenericRepository<Employee> _employees;
        private IGenericRepository<Employment> _employments;
        private IGenericRepository<EmployeeTerritory> _teritories;
        private IGenericRepository<Order> _orders;
        private IGenericRepository<OrderDetail> _orderDetails;

       

        #region Properties
        public IGenericRepository<Employee> Employees {
            get
            {

                if (this._employees == null)
                {
                    this._employees = new GenericRepository<Employee>(context);
                }
                return _employees;
            }
        }
        public IGenericRepository<Employment> Employments {
            get
            {

                if (this._employments == null)
                {
                    this._employments = new GenericRepository<Employment>(context);
                }
                return _employments;
            } }
        public IGenericRepository<EmployeeTerritory> Teritories {
            get
            {

                if (this._teritories == null)
                {
                    this._teritories = new GenericRepository<EmployeeTerritory>(context);
                }
                return _teritories;
            }
        }
        public IGenericRepository<Order> Orders {
            get
            {

                if (this._orders == null)
                {
                    this._orders = new GenericRepository<Order>(context);
                }
                return _orders;
            }
        }
        public IGenericRepository<OrderDetail> OrderDetails {
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
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
