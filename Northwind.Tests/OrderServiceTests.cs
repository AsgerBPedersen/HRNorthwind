using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Northwind.DataAcess;
using Northwind.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Tests
{
    [TestClass]
    public class OrderServiceTests
    {   
        [TestMethod]
        public void OrderService_GetById()
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

            var repo = new Mock<IGenericRepository<Order>>();

            repo.Setup(r => r.GetById(1, new string[4] { "Employee", "Customer", "ShipViaNavigation", "OrderDetails.Product" })).Returns(Task.FromResult(order));

            OrderService orderService = new OrderService();

            orderService.Orders = repo.Object;

            var actual = orderService.GetById(1);

            Assert.AreEqual(actual.Result.OrderId, order.OrderId);
        }
    }
}
