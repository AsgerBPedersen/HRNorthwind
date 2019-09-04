using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.DataAcess;
using Northwind.Entities.Models;
using System.Linq;

namespace Northwind.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void AddEmployee()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<NorthwindContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new NorthwindContext(options))
                {
                    context.Database.EnsureCreated();
                }

                Employee emp = new Employee()
                {
                    FirstName = "Asger",
                    LastName = "Pedersen",
                    Email = "123@asd.dk"
                };

                // Run the test against one instance of the context
                using (var context = new NorthwindContext(options))
                {
                    var service = new EmployeeRepository(context);
                    service.AddEmployee(emp);
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new NorthwindContext(options))
                {
                    Assert.AreEqual(1, context.Employees.Count());
                    Assert.AreEqual(emp.FirstName, context.Employees.Single().FirstName);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
