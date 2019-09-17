using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.WebServices.Objects
{
    public class Rates
    {
        public double DKK { get; set; }
        public double CAD { get; set; }
        public double EUR { get; set; }
        public double GBP { get; set; }
    }

    public class ExchangeRates
    {
        public string disclaimer { get; set; }
        public string license { get; set; }
        public int timestamp { get; set; }
        public string @base { get; set; }
        public Rates rates { get; set; }
    }
}
