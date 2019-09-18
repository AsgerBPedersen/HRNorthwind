using System;
using System.Collections.Generic;

namespace Northwind.Entities.Models
{
    public partial class OrderDetail : IEntityWithId 
    {

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public int Id => OrderId;
    }
}
