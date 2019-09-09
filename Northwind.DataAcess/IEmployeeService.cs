using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcess
{
    public interface IEmployeeService
    {
        IList<Employee> GetEmployees();

        Employee GetById(int id);

        Employee GetEmployeeByName(string name);

        Employee GetEmployeeByInitials(string initials);

        void AddEmployee(Employee employee);

        Task DeleteEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        Task<IList<Employee>> GetEmployeesFiltered(string country, string title, string region, string firstName, string lastName, string initials);

        void DeleteEmployment(int employeeId, int employmentId);

        void AddEmployment(int id);
    }
}
