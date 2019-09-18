using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.WebServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Tests
{
    [TestClass]
    public class WebserviceTest
    {
        [TestMethod]
        public void Invalid_ExchangeRateService()
        {
            ExchangeRateService.Api = "badconnection.dk";
            var res = ExchangeRateService.GetRates();
            Assert.IsTrue(res == null);
        }
        [TestMethod]
        public void Valid_ExchangeRateService()
        {
            var res = ExchangeRateService.GetRates();
            Assert.IsTrue(res.rates.EUR > 0);
        }

        
    }
}
