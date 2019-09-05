using Microsoft.EntityFrameworkCore;

namespace Northwind.Entities.Models
{
    public interface INorthwindContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<CustomerCustomerDemo> CustomerCustomerDemoes { get; set; }
        DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        DbSet<Employment> Employments { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Shipper> Shippers { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Territory> Territories { get; set; }
    }
}