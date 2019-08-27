using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Entities.Models;

namespace Northwind.DataAcess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly NorthwindContext Db;

        public EmployeeRepository()
        {
            Db = new NorthwindContext();
        }
        public void DeleteEmployee(Employee employee)
        {
            var teritories = Db.EmployeeTerritories.Where(t => t.EmployeeId == employee.EmployeeId);
            var orders = Db.Orders.Where(o => o.EmployeeId == employee.EmployeeId);
            foreach (var item in orders)
            {
                var orderdetails = Db.OrderDetails.Where(o => o.OrderId == item.OrderId);
                Db.OrderDetails.RemoveRange(orderdetails);
            }
            Db.Orders.RemoveRange(orders);
            Db.EmployeeTerritories.RemoveRange(teritories);
            Db.Employees.Remove(employee);
            Db.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            return Db.Employees.SingleOrDefault(e => e.EmployeeId == id);
        }

        public Employee GetEmployeeByInitials(string initials)
        {
            return Db.Employees.SingleOrDefault(e => e.Extension == initials);
        }

        public Employee GetEmployeeByName(string name)
        {
            return Db.Employees.SingleOrDefault(e => e.FirstName == name);
        }

        public IList<Employee> GetEmployees()
        {
            return Db.Employees.ToList();
        }

        public IList<Employee> GetEmployeesByCountryAndEmployment(string Country = null, string title = null)
        {
            if (Country == null)
            {
                if (title == null)
                {
                    return GetEmployees();
                } 
                 return Db.Employees.Where(e => e.Title == title).ToList();
            }

            if (title == null)
            {
                return Db.Employees.Where(e => e.Country == Country).ToList();
            }

            return Db.Employees.Where(e => e.Country == Country && e.Title == title).ToList();
        }

        public IList<Employee> GetEmployeesByRegionAndEmployment(string region, string title)
        {
            if (region == "")
            {
                if (title == "")
                {
                    return GetEmployees();
                }
                return Db.Employees.Where(e => e.Title.Contains(title)).ToList();
            }

            if (title == "")
            {
                return Db.Employees.Where(e => e.Region == region).ToList();
            }

            return Db.Employees.Where(e => e.Region == region && e.Title.Contains(title)).ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            Db.Employees.Update(employee);
            Db.SaveChanges();
        }
    }
}
