using System;
using System.Collections.Generic;
using System.Text;
using Northwind.DataAcess;
using Northwind.Entities.Models;

namespace Northwind.Services
{
    class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employees;
        private readonly IGenericRepository<Employment> _employments;

        public EmployeeService(IGenericRepository<Employee> employees, IGenericRepository<Employment> employments)
        {
            _employees = employees;
            _employments = employments;
        }

        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void AddEmployment(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployment(int employeeId, int employmentId)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IList<Employee> GetEmployeesFiltered(string country, string title, string region, string firstName, string lastName, string initials)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
