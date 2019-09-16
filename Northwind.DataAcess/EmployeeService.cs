using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAcess;
using Northwind.Entities.Models;

namespace Northwind.DataAcess
{
    public class EmployeeService : IEmployeeService
    {
        private NorthwindContext context = new NorthwindContext();
        private IGenericRepository<Employee> _employees;
        private IGenericRepository<Employment> _employments;
        private IGenericRepository<EmployeeTerritory> _teritories;
        private IGenericRepository<Order> _orders;
        private IGenericRepository<OrderDetail> _orderDetails;

        #region Properties
        public IGenericRepository<Employee> Employees
        {
            get
            {

                if (this._employees == null)
                {
                    this._employees = new GenericRepository<Employee>(context);
                }
                return _employees;
            }
        }
        public IGenericRepository<Employment> Employments
        {
            get
            {

                if (this._employments == null)
                {
                    this._employments = new GenericRepository<Employment>(context);
                }
                return _employments;
            }
        }
        public IGenericRepository<EmployeeTerritory> Teritories
        {
            get
            {

                if (this._teritories == null)
                {
                    this._teritories = new GenericRepository<EmployeeTerritory>(context);
                }
                return _teritories;
            }
        }
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

        public async Task<int> AddEmployee(Employee employee)
        {
           return await Employees.Add(employee);
        }


        public async Task DeleteEmployee(Employee employee)
        {
            var teritories = await Teritories.List(t => t.EmployeeId == employee.EmployeeId);
            var orders = await Orders.List(o => o.EmployeeId == employee.EmployeeId);
            var employments = await Employments.List(e => e.EmployeeId == employee.EmployeeId);


            foreach (var item in orders)
            {
                var orderdetails = await _orderDetails.List(o => o.OrderId == item.OrderId);
                await _orderDetails.DeleteRange(orderdetails);
            }


            await _orders.DeleteRange(orders);
            await _teritories.DeleteRange(teritories);
            await Employments.DeleteRange(employments);
            await Employees.Delete(employee);
        }


        public async Task<Employee> GetById(int id)
        {
            return await Employees.GetById(id, "Employments");
        }


        public async Task<IList<Employee>> GetEmployees()
        {
            return await Employees.List("Employments");
        }

        public async Task<IList<Employee>> GetEmployeesFiltered(string country, string title, string region, string firstName, string lastName, string initials)
        {
            return await Employees.List(e => e.Country.IndexOf(country) != -1 && e.Title.IndexOf(title) != -1 && e.Region.IndexOf(region) != -1 && e.FirstName.IndexOf(firstName) != -1 && e.LastName.IndexOf(lastName) != -1 && e.Initials.IndexOf(initials) != -1);
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
           return await Employees.Edit(employee);
        }
        public async Task<int> DeleteEmployment(int employeeId, int employmentId)
        {
            var employees = await Employees.List("Employments");
            var employee = employees.SingleOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                throw new NullReferenceException("Employee not found");
            }
            return await Employments.Delete(employee.Employments.Single(e => e.EmploymentId == employmentId));
        }
        public async Task<int> AddEmployment(int id)
        {
            var employee = await Employees.GetById(id, "Employments");
            var newEmployment = new Employment() { HireDate = DateTime.Now.Date, EmployeeId = employee.EmployeeId };
            return await Employments.Add(newEmployment);
        }
    }
}
