using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Tests
{
    [TestClass]
    public class OrderModelTests
    {
        [TestMethod]
        public void Valid_Initialization_Order()
        {
            Order order = new Order()
            {
                OrderId = 1,
                CustomerId = "1",
                EmployeeId = 1,
                OrderDate = DateTime.Now.AddDays(-1),
                RequiredDate = DateTime.Now,
                ShippedDate = DateTime.Now,
                Freight = 20,
                ShipName = "Bob",
                ShipAddress = "Bob vej 2",
                ShipCity = "Byen Hat",
                ShipRegion = "Sommerstad",
                ShipPostalCode = "123",
                ShipCountry = "asd"
            };
        }
        [TestMethod]
        public void Invalid_Initialization_1_Order()
        {
            Order order = null;
            try
            {
                order = new Order()
                {
                    OrderId = -1,
                    CustomerId = "1",
                    EmployeeId = 1,
                    OrderDate = DateTime.Now.AddDays(-1),
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    Freight = 20,
                    ShipName = "Bob",
                    ShipAddress = "Bob vej 2",
                    ShipCity = "Byen Hat",
                    ShipRegion = "Sommerstad",
                    ShipPostalCode = "123",
                    ShipCountry = "asd"
                };
            }
            catch (Exception)
            {

            }
            
            Assert.AreEqual(order, null);
        }

        [TestMethod]
        public void Invalid_Initialization_2_Order()
        {
            Order order = null;
            try
            {
                order = new Order()
                {
                    OrderId = 1,
                    CustomerId = "1",
                    EmployeeId = 1,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(-1),
                    ShippedDate = DateTime.Now,
                    Freight = 20,
                    ShipName = "Bob",
                    ShipAddress = "Bob vej 2",
                    ShipCity = "Byen Hat",
                    ShipRegion = "Sommerstad",
                    ShipPostalCode = "123",
                    ShipCountry = "asd"
                };
            }
            catch (Exception)
            {

            }

            Assert.AreEqual(order, null);
        }
    }
}
