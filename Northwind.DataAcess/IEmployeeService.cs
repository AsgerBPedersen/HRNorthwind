using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcess
{
    public interface IEmployeeService
    {
        Task<IList<Employee>> GetEmployees();

        Task<Employee> GetById(int id);

        Task<int> AddEmployee(Employee employee);

        Task DeleteEmployee(Employee employee);

        Task<int> UpdateEmployee(Employee employee);

        Task<IList<Employee>> GetEmployeesFiltered(string country, string title, string region, string firstName, string lastName, string initials);

        Task<int> DeleteEmployment(int employeeId, int employmentId);

        Task<int> AddEmployment(int id);
    }
}
