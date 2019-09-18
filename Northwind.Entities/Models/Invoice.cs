using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Northwind.Entities.Models
{
    public partial class Invoice
    {
        [DisplayName("Modtager navn")]
        public string ShipName { get; set; }
        [DisplayName("Modtager addresse")]
        public string ShipAddress { get; set; }
        [DisplayName("Modtager by")]
        public string ShipCity { get; set; }
        [DisplayName("Modtager region")]
        public string ShipRegion { get; set; }
        [DisplayName("Modtager postnummer")]
        public string ShipPostalCode { get; set; }
        [DisplayName("Modtager land")]
        public string ShipCountry { get; set; }
        public string CustomerId { get; set; }
        [DisplayName("Navn")]
        public string CustomerName { get; set; }
        [DisplayName("Addresse")]
        public string Address { get; set; }
        [DisplayName("By")]
        public string City { get; set; }
        [DisplayName("Region")]
        public string Region { get; set; }
        [DisplayName("Postnummer")]
        public string PostalCode { get; set; }
        [DisplayName("Land")]
        public string Country { get; set; }
        [DisplayName("Sælger")]
        public string Salesperson { get; set; }
        public int OrderId { get; set; }
        [DisplayName("Ordre dato")]
        public DateTime? OrderDate { get; set; }
        [DisplayName("Leverings dato")]
        public DateTime? RequiredDate { get; set; }
        [DisplayName("Afsendelses dato")]
        public DateTime? ShippedDate { get; set; }
        [DisplayName("Transportør")]
        public string ShipperName { get; set; }
        public int ProductId { get; set; }
        [DisplayName("Product navn")]
        public string ProductName { get; set; }
        [DisplayName("Enheds pris")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Antal")]
        public short Quantity { get; set; }
        [DisplayName("Rabat")]
        public float Discount { get; set; }
        [DisplayName("Samlet pris")]
        public decimal? ExtendedPrice { get; set; }
        [DisplayName("Fragt")]
        public decimal? Freight { get; set; }
    }
}
