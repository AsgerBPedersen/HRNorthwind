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
            var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Delete_employment_from_database")
            .Options;


            Employee emp = new Employee()
            {
                EmployeeId = 1,
                FirstName = "Asger",
                LastName = "Pedersen",
                Email = "123@asd.dk"
            };

            Employment employment = new Employment()
            {
                EmploymentId = 1,
                EmployeeId = 1,
                HireDate = DateTime.Now.Date
            };

            int before = 0;
            // Run the test against one instance of the context
            using (var context = new NorthwindContext(options))
            {
                var service = new EmployeeRepository(context);
                service.AddEmployee(emp);
                context.Employments.Add(employment);
                context.SaveChanges();
            }

            using (var context = new NorthwindContext(options))
            {
                var service = new EmployeeRepository(context);
                before = context.Employments.Count();
                service.DeleteEmployment(1, 1);
                context.SaveChanges();
            }


            // Use a separate instance of the context to verify correct data was deleted from database
            using (var context = new NorthwindContext(options))
            {
                Assert.AreEqual(1, before);
                Assert.AreEqual(0, context.Employments.Count());

            }
        }

        [TestMethod]
        public void AddEmployment()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Add_employment_to_database")
            .Options;


            Employee emp = new Employee()
            {
                EmployeeId = 1,
                FirstName = "Asger",
                LastName = "Pedersen",
                Email = "123@asd.dk"
            };


            // Run the test against one instance of the context
            using (var context = new NorthwindContext(options))
            {
                var service = new EmployeeRepository(context);
                service.AddEmployee(emp);
                service.AddEmployment(1);
                context.SaveChanges();
            }



            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new NorthwindContext(options))
            {
                Assert.AreEqual(1, context.Employments.Count());
                Assert.AreEqual(1, context.Employments.Single().EmploymentId);
            }
        }

    }
}
