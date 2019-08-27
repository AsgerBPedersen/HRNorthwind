using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAcess
{
    public interface IEmployeeRepository
    {
        IList<Employee> GetEmployees();

        Employee GetEmployeeById(int id);

        Employee GetEmployeeByName(string name);

        Employee GetEmployeeByInitials(string initials);

        void DeleteEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        IList<Employee> GetEmployeesByCountryAndEmployment(string country, string title);

        IList<Employee> GetEmployeesByRegionAndEmployment(string region, string title);
    }
}
