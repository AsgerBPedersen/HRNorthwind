using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Northwind.Entities.Models
{
    public partial class Order : IEntityWithId
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>().ToList();
        }

        public int OrderId { get; set; }
        [DisplayName("Kunde")]
        public string CustomerId { get; set; }
        [DisplayName("Ansat")]
        public int? EmployeeId { get; set; }
        [DisplayName("Ordre dato")]
        public DateTime? OrderDate { get; set; }
        [DisplayName("Leverings dato")]
        public DateTime? RequiredDate { get; set; }
        [DisplayName("Afsendelses dato")]
        public DateTime? ShippedDate { get; set; }
        [DisplayName("Sendes via")]
        public int? ShipVia { get; set; }
        [DisplayName("Vægt")]
        public decimal? Freight { get; set; }
        [DisplayName("Modtager")]
        public string ShipName { get; set; }
        [DisplayName("Adresse")]
        public string ShipAddress { get; set; }
        [DisplayName("By")]
        public string ShipCity { get; set; }
        [DisplayName("Region")]
        public string ShipRegion { get; set; }
        [DisplayName("Postnummer")]
        public string ShipPostalCode { get; set; }
        [DisplayName("Land")]
        public string ShipCountry { get; set; }
        [DisplayName("Kunde")]
        public virtual Customer Customer { get; set; }
        [DisplayName("Ansat")]
        public virtual Employee Employee { get; set; }
        [DisplayName("Sendes via")]
        public virtual Shipper ShipViaNavigation { get; set; }
        [DisplayName("Ordre detaljer")]
        public virtual IList<OrderDetail> OrderDetails { get; set; }

        public int Id => OrderId;
    }
}
