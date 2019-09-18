using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Northwind.Entities.Models
{
    public partial class Order : IEntityWithId
    {
        #region Fields
        private int orderId;
        private string customerId;
        private int? employeeId;
        private DateTime orderDate;
        private DateTime? requiredDate;
        private DateTime? shippedDate;
        private int? shipVia;
        private decimal? freight;
        private string shipName;
        private string shipAddress;
        private string shipCity;
        private string shipRegion;
        private string shipPostalCode;
        private string shipCountry;
        private Customer customer;
        private Employee employee;
        private Shipper shipViaNavigation;
        private IList<OrderDetail> orderDetails;
        #endregion
        /// <summary>
        /// Instantiates new Order with Orderdetails.
        /// </summary>
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>().ToList();
        }
        #region Properties
        /// <summary>
        /// Gets or sets OrderId
        /// </summary>
        public int OrderId
        {
            get => orderId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Ids can't be 0 or less.");
                }
                orderId = value;
            }
        }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        [DisplayName("Kunde")]
        public string CustomerId
        {
            get => customerId;
            set
            {
                if (int.Parse(value) <= 0)
                {
                    throw new ArgumentException("Ids can't be 0 or less.");
                }
                customerId = value;
            }
        }
        /// <summary>
        /// Gets or sets EmployeeId
        /// </summary>
        [DisplayName("Ansat")]
        public int? EmployeeId
        {
            get => employeeId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Ids can't be 0 or less.");
                }
                employeeId = value;
            }
        }
        /// <summary>
        /// Gets or sets Orderdate
        /// </summary>
        [DisplayName("Ordre dato")]
        public DateTime OrderDate
        {
            get => orderDate;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Order date can't be null");
                }
                orderDate = value;
            }
        }
        /// <summary>
        /// Gets or sets RequiredDate
        /// </summary>
        [DisplayName("Leverings dato")]
        public DateTime? RequiredDate
        {
            get => requiredDate;
            set
            {
                if (value != null)
                {
                    var res = ValidateRequiredDate((DateTime)value, OrderDate);
                    if (!res.isValid)
                    {
                        throw new ArgumentException(res.Error);
                    }
                }
                requiredDate = value;
            }
        }
        /// <summary>
        /// Gets or sets ShippedDate
        /// </summary>
        [DisplayName("Afsendelses dato")]
        public DateTime? ShippedDate
        {
            get => shippedDate;
            set
            {
                if (value != null)
                {
                    var res = ValidateShippeddDate((DateTime)value, OrderDate);
                    if (!res.isValid)
                    {
                        throw new ArgumentException(res.Error);
                    }
                }
                shippedDate = value;
            }
        }
        /// <summary>
        /// Gets or sets ShipVia
        /// </summary>
        [DisplayName("Sendes via")]
        public int? ShipVia { get => shipVia; set => shipVia = value; }
        [DisplayName("Vægt")]
        public decimal? Freight
        {
            get => freight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Freight can't be less than 0.");
                }
                freight = value;
            }
        }
        /// <summary>
        /// Gets or sets ShipName
        /// </summary>
        [DisplayName("Modtager")]
        public string ShipName
        {
            get => shipName;
            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-ZæøåÆØÅ]+$"))
                {
                    throw new ArgumentException("Name can only cotain letters.");
                }
                if (value.Length > 40)
                {
                    throw new ArgumentException("Name can't be longer than 40 characters.");
                }
                shipName = value;
            }
        }
        /// <summary>
        /// Gets or sets ShipAddress
        /// </summary>
        [DisplayName("Adresse")]
        public string ShipAddress { 
            get => shipAddress;
            set {
                if (value.Length > 60)
                {
                    throw new ArgumentException("Address can't be longer than 60 characters.");
                }
                shipAddress = value;
            } 
        }
        /// <summary>
        /// Gets or sets ShipCity
        /// </summary>
        [DisplayName("By")]
        public string ShipCity { 
            get => shipCity; 
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("City can't be longer than 15 characters.");
                }
                shipCity = value;
            }
        }
        /// <summary>
        /// Gets or sets ShipRegion
        /// </summary>
        [DisplayName("Region")]
        public string ShipRegion {
            get => shipRegion;
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("Region can't be longer than 15 characters.");
                }
                shipRegion = value;
            }
        }
        /// <summary>
        /// Gets or sets PostalCode
        /// </summary>
        [DisplayName("Postnummer")]
        public string ShipPostalCode
        {
            get => shipPostalCode;
            set
            {
                if (!Regex.IsMatch(value, @"^[0-9]+$"))
                {
                    throw new ArgumentException("Postal code can only contain letters");
                }
                if (value.Length > 10)
                {
                    throw new ArgumentException("Postal code can't be longer than 10 characters.");
                }
                shipPostalCode = value;
            }
        }
        /// <summary>
        /// Gets or sets ShipCountry
        /// </summary>
        [DisplayName("Land")]
        public string ShipCountry { 
            get => shipCountry;
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("Country can't be longer than 15 characters.");
                }
                shipCountry = value;
            }
        }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        [DisplayName("Kunde")]
        public virtual Customer Customer { get => customer; set => customer = value; }
        /// <summary>
        /// Gets or sets Employee
        /// </summary>
        [DisplayName("Ansat")]
        public virtual Employee Employee { get => employee; set => employee = value; }
        /// <summary>
        /// Gets or sets ShipViaNavigation
        /// </summary>
        [DisplayName("Sendes via")]
        public virtual Shipper ShipViaNavigation { get => shipViaNavigation; set => shipViaNavigation = value; }
        /// <summary>
        /// Gets or sets OrderDetails
        /// </summary>
        [DisplayName("Ordre detaljer")]
        public virtual IList<OrderDetail> OrderDetails { get => orderDetails; set => orderDetails = value; }
        /// <summary>
        /// Returns the Id needed for the generic repository
        /// </summary>
        public int Id => OrderId;
        #endregion
        /// <summary>
        /// Validates the RequiredDate againts the OrderDate
        /// </summary>
        /// <param name="requiredDate"></param>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        public static (bool isValid, string Error) ValidateRequiredDate(DateTime requiredDate, DateTime orderDate)
        {
            if (requiredDate < orderDate)
            {
                return (false, "Required date can't be set before order date.");
            }

            return (true, string.Empty);
        }
        /// <summary>
        /// Validates the ShippedDate against the OrderDate
        /// </summary>
        /// <param name="ShippeddDate"></param>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        public static (bool isValid, string Error) ValidateShippeddDate(DateTime ShippeddDate, DateTime orderDate)
        {
            if (ShippeddDate < orderDate)
            {
                return (false, "Shipped date can't be set before order date.");
            }

            return (true, string.Empty);
        }
    }
}
