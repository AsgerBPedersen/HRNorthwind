﻿using System;
using System.Collections.Generic;

namespace Northwind.Entities.Models
{
    public partial class Customer : IEntityWithId
    {
        public Customer()
        {
            CustomerCustomerDemoes = new HashSet<CustomerCustomerDemo>();
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemoes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public int Id => throw new NotImplementedException();
    }
}
