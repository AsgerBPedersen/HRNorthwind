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

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }


        public async Task DeleteEmployee(Employee employee)
        {
            var teritories = await _teritories.List(t => t.EmployeeId == employee.EmployeeId);
            var orders = await _orders.List(o => o.EmployeeId == employee.EmployeeId);
            var employments = await _employments.List(e => e.EmployeeId == employee.EmployeeId);


            foreach (var item in orders)
            {
                var orderdetails = await _orderDetails.List(o => o.OrderId == item.OrderId);
                _orderDetails.DeleteRange(orderdetails);
            }


            _orders.DeleteRange(orders);
            _teritories.DeleteRange(teritories);
            _employments.DeleteRange(employments);
            _employees.Delete(employee);
        }


        public Employee GetById(int id)
        {
            return _employees.GetById(id, "Employments");
        }

        public Employee GetEmployeeByInitials(string initials)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByName(string name)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetEmployees()
        {
            return _employees.List("Employments").ToList();
        }

        public async Task<IList<Employee>> GetEmployeesFiltered(string country, string title, string region, string firstName, string lastName, string initials)
        {
            return await _employees.List(e => e.Country.IndexOf(country) != -1 && e.Title.IndexOf(title) != -1 && e.Region.IndexOf(region) != -1 && e.FirstName.IndexOf(firstName) != -1 && e.LastName.IndexOf(lastName) != -1 && e.Initials.IndexOf(initials) != -1);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employees.Edit(employee);
        }
        public void DeleteEmployment(int employeeId, int employmentId)
        {
            var employee = _employees.List("Employments").SingleOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                throw new NullReferenceException("Employee not found");
            }
            _employments.Delete(employee.Employments.Single(e => e.EmploymentId == employmentId));
        }
        public void AddEmployment(int id)
        {
            var employee = _employees.GetById(id, "Employments");
            var newEmployment = new Employment() { HireDate = DateTime.Now.Date, EmployeeId = employee.EmployeeId };
            if (!employee.EmploymentValidation(newEmployment))
            {
                throw new ArgumentException("Employments can't overlap");
            }
            _employments.Add(newEmployment);
        }
    }
}
