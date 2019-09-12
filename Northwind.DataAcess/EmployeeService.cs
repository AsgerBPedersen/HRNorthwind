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
        private readonly IGenericRepository<Employee> _employees;
        private readonly IGenericRepository<Employment> _employments;
        private readonly IGenericRepository<EmployeeTerritory> _teritories;
        private readonly IGenericRepository<Order> _orders;
        private readonly IGenericRepository<OrderDetail> _orderDetails;


        public EmployeeService()
        {
            var _context = new NorthwindContext();
            _employees = new GenericRepository<Employee>(_context);
            _employments = new GenericRepository<Employment>(_context);
            _orders = new GenericRepository<Order>(_context);
            _teritories = new GenericRepository<EmployeeTerritory>(_context);
            _orderDetails = new GenericRepository<OrderDetail>(_context);
        }

        public EmployeeService(IGenericRepository<Employee> employees, IGenericRepository<Employment> employments, IGenericRepository<Order> orders, IGenericRepository<EmployeeTerritory> teritories, IGenericRepository<OrderDetail> orderDetails)
        {
            _employees = employees;
            _employments = employments;
            _teritories = teritories;
            _orders = orders;
            _orderDetails = orderDetails;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
           return await _employees.Add(employee);
        }


        public async Task DeleteEmployee(Employee employee)
        {
            var teritories = await _teritories.List(t => t.EmployeeId == employee.EmployeeId);
            var orders = await _orders.List(o => o.EmployeeId == employee.EmployeeId);
            var employments = await _employments.List(e => e.EmployeeId == employee.EmployeeId);


            foreach (var item in orders)
            {
                var orderdetails = await _orderDetails.List(o => o.OrderId == item.OrderId);
                await _orderDetails.DeleteRange(orderdetails);
            }


            await _orders.DeleteRange(orders);
            await _teritories.DeleteRange(teritories);
            await _employments.DeleteRange(employments);
            await _employees.Delete(employee);
        }


        public async Task<Employee> GetById(int id)
        {
            return await _employees.GetById(id, "Employments");
        }


        public async Task<IList<Employee>> GetEmployees()
        {
            return await _employees.List("Employments");
        }

        public async Task<IList<Employee>> GetEmployeesFiltered(string country, string title, string region, string firstName, string lastName, string initials)
        {
            return await _employees.List(e => e.Country.IndexOf(country) != -1 && e.Title.IndexOf(title) != -1 && e.Region.IndexOf(region) != -1 && e.FirstName.IndexOf(firstName) != -1 && e.LastName.IndexOf(lastName) != -1 && e.Initials.IndexOf(initials) != -1);
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
           return await _employees.Edit(employee);
        }
        public async Task<int> DeleteEmployment(int employeeId, int employmentId)
        {
            var employees = await _employees.List("Employments");
            var employee = employees.SingleOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                throw new NullReferenceException("Employee not found");
            }
            return await _employments.Delete(employee.Employments.Single(e => e.EmploymentId == employmentId));
        }
        public async Task<int> AddEmployment(int id)
        {
            var employee = await _employees.GetById(id, "Employments");
            var newEmployment = new Employment() { HireDate = DateTime.Now.Date, EmployeeId = employee.EmployeeId };
            return await _employments.Add(newEmployment);
        }
    }
}
