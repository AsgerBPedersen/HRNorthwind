using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Northwind.DataAcess;
using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void AddEmployee()
        {

            
                var options = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;


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
        [TestMethod]
        public void FindEmployeeById()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Find_by_id_in_database")
            .Options;


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
                var service = new EmployeeRepository(context);
                int id = context.Employees.Single().EmployeeId;
                Assert.AreEqual(1, context.Employees.Count());
                Assert.AreEqual(id, service.GetEmployeeById(id).EmployeeId);
            }

        }

        [TestMethod]
        public void FindEmployeeByInitials()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Find_by_initials_in_database")
            .Options;


            Employee emp = new Employee()
            {
                FirstName = "Asger",
                LastName = "Pedersen",
                Initials = "ASPE",
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
                var service = new EmployeeRepository(context);
                string i = context.Employees.Single().Initials;
                Assert.AreEqual(1, context.Employees.Count());
                Assert.AreEqual(i, service.GetEmployeeByInitials(i).Initials);
            }

        }

        [TestMethod]
        public void FindEmployeeByName()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Find_by_name_in_database")
            .Options;


            Employee emp = new Employee()
            {
                FirstName = "Asger",
                LastName = "Pedersen",
                Initials = "ASPE",
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
                var service = new EmployeeRepository(context);
                string name = context.Employees.Single().FirstName;
                Assert.AreEqual(1, context.Employees.Count());
                Assert.AreEqual(name, service.GetEmployeeByName(name).FirstName);
            }

        }
        [TestMethod]
        public void DeleteEmployee()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Delete_from_database")
            .Options;


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
                var service = new EmployeeRepository(context);
                Employee e = context.Employees.Single();
                service.DeleteEmployee(e);
                Assert.AreEqual(0, context.Employees.Count());
                
            }

        }

        [TestMethod]
        public void GetEmployees()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Get_employees_from_database")
            .Options;


            Employee emp1 = new Employee()
            {
                FirstName = "Asger",
                LastName = "Pedersen",
                Email = "123@asd.dk"
            };

            Employee emp2 = new Employee()
            {
                FirstName = "Bob",
                LastName = "Hans",
                Email = "123@asd.dk"
            };

            // Run the test against one instance of the context
            using (var context = new NorthwindContext(options))
            {
                var service = new EmployeeRepository(context);
                service.AddEmployee(emp1);
                service.AddEmployee(emp2);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new NorthwindContext(options))
            {
                var service = new EmployeeRepository(context);
                Assert.AreEqual(2, service.GetEmployees().Count);

            }

        }

        [TestMethod]
        public void GetEmployeesFiltered()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Get_employees_filtered_from_database")
            .Options;


            Employee emp1 = new Employee()
            {
                FirstName = "Asger",
                LastName = "Pedersen",
                Initials = "ASPE",
                Title = "Tophat",
                Country = "denmark",
                Region = "kbh",
                Email = "123@asd.dk"
            };

            Employee emp2 = new Employee()
            {
                FirstName = "Bob",
                LastName = "Hans",
                Initials = "ASPE",
                Title = "Tophat",
                Country = "denmark",
                Region = "kbh",
                Email = "123@asd.dk"
            };

            // Run the test against one instance of the context
            using (var context = new NorthwindContext(options))
            {
                var service = new EmployeeRepository(context);
                service.AddEmployee(emp1);
                service.AddEmployee(emp2);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new NorthwindContext(options))
            {
                var service = new EmployeeRepository(context);
                Assert.AreEqual(1, service.GetEmployeesFiltered("","","","Bob","Hans","").Count);
                Assert.AreEqual(1, service.GetEmployeesFiltered("", "", "", "As", "", "ASPE").Count);
            }

        }
        [TestMethod]
        public void Updatemployee()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Update_employee_in_database")
            .Options;


            Employee emp = new Employee()
            {
                FirstName = "Asger",
                LastName = "Pedersen",
                Email = "123@asd.dk"
            };
            string newName = "Peder";

            // Run the test against one instance of the context
            using (var context = new NorthwindContext(options))
            {
                var service = new EmployeeRepository(context);
                service.AddEmployee(emp);
                context.SaveChanges();
            }
            //update employee
            using (var context = new NorthwindContext(options))
            {
                var service = new EmployeeRepository(context);
                Employee e = context.Employees.Single();
                e.FirstName = newName;
                service.UpdateEmployee(e);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new NorthwindContext(options))
            {             
                var service = new EmployeeRepository(context);
                Assert.AreEqual(newName, context.Employees.Single().FirstName);
            }

        }

        [TestMethod]
        public void DeleteEmployment()
        {
            //List<Employee> emp = new List<Employee>
            //{
            //    new Employee
            //    {
            //        EmployeeId = 1,
            //        FirstName = "Asger",
            //        LastName = "Pedersen",
            //        Email = "123@asd.dk",
            //        Employments = new List<Employment>
            //    {
            //        new Employment
            //        {
            //            EmployeeId = 1,
            //            EmploymentId = 1,
            //            HireDate = DateTime.Now.Date
            //        }
            //    }
            //    }
            //};

            //// generates mock dbsets
            //var mockEmployeeSet = GetQueryableMockDbSet(emp);
            //var mockEmploymentSet = GetQueryableMockDbSet(new List<Employment> { emp.Single().Employments.Single() });

            //// generates mock dbcontext and adds the relevant db sets.
            //var mockContext = new Mock<NorthwindContext>();
            //mockContext.Setup(c => c.Employees).Returns(mockEmployeeSet);
            //mockContext.Setup(c => c.Employments).Returns(mockEmploymentSet);

            ////initializes the repo with the mock context
            //var repo = new EmployeeRepository(mockContext.Object);


            //int before = repo.GetEmployees().Single().Employments.Count;
            //repo.DeleteEmployment(1, 1);
            //int after = repo.GetEmployees().Single().Employments.Count;
            //Assert.IsTrue(before == 1);
            //Assert.IsTrue(after == 0);

        }
        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return dbSet.Object;
        }
    }
}
