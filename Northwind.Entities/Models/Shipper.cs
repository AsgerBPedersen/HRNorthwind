﻿using System;
using System.Collections.Generic;

namespace Northwind.Entities.Models
{
    public partial class Shipper : IEntityWithId
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public int Id => throw new NotImplementedException();
    }
}
