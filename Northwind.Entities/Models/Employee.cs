using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Northwind.Entities.Models
{
    public partial class Employee
    {

        public Employee()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
            Employments = new HashSet<Employment>().ToList();
            InverseReportsToNavigation = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Du skal skrive et navn")]
        [DisplayName("Efternavn")]
        [MaxLength(20, ErrorMessage = "Efternavn kan ikke være længere end 4.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Du skal skrive et navn")]
        [DisplayName("Fornavn")]
        [MaxLength(10, ErrorMessage = "Fornavn kan ikke være længere end 10.")]
        public string FirstName { get; set; }
        [DisplayName("Stilling")]
        [MaxLength(30, ErrorMessage = "Stilling kan ikke være længere end 30.")]
        public string Title { get; set; }
        [DisplayName("Titel")]
        public string TitleOfCourtesy { get; set; }
        [DisplayName("Fødselsdag")]
        public DateTime? BirthDate { get; set; }
        [DisplayName("Adresse")]
        [MaxLength(60, ErrorMessage = "Addresse kan ikke være længere end 60.")]
        public string Address { get; set; }
        [MaxLength(15, ErrorMessage = "By kan ikke være længere end 15.")]
        [DisplayName("By")]
        public string City { get; set; }
        [MaxLength(15, ErrorMessage = "Region  kan ikke være længere end 15.")]
        [DisplayName("Region")]
        public string Region { get; set; }
        [MaxLength(10, ErrorMessage = "Postnummer kan ikke være længere end 10.")]
        [DisplayName("Postnummer")]
        public string PostalCode { get; set; }
        [MaxLength(15, ErrorMessage = "Land kan ikke være længere end 15.")]
        [DisplayName("Land")]
        public string Country { get; set; }
        [DisplayName("Hjemme telefon")]
        [MaxLength(24, ErrorMessage = "Nummer kan ikke være længere end 24.")]
        public string HomePhone { get; set; }
        [MaxLength(4, ErrorMessage = "Område kode kan ikke være længere end 4.")]
        [DisplayName("Område kode")]
        public string Extension { get; set; }
        [DisplayName("Foto")]
        public byte[] Photo { get; set; }
        [DisplayName("Noter")]
        public string Notes { get; set; }
        [DisplayName("Raportere til")]
        public int? ReportsTo { get; set; }
        [DisplayName("Foto sti")]
        public string PhotoPath { get; set; }
        [MaxLength(4, ErrorMessage = "Initialer kan ikke være længere end 4.")]
        [DisplayName("Initialer")]
        public string Initials { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Arbejdstelefon")]
        [MaxLength(24, ErrorMessage = "Nummer kan ikke være længere end 24.")]
        public string WorkPhone { get; set; }

        public virtual Employee ReportsToNavigation { get; set; }
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        [ValidateDates]
        public virtual IList<Employment> Employments { get; set; }
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public bool EmploymentValidation(Employment employment)
        {
            if (Employments.SingleOrDefault(e => e.HireDate < employment.LeaveDate && employment.HireDate < e.LeaveDate || e.LeaveDate == null && employment.LeaveDate == null) != null)
            {
                return false;
            }
            return true;
        }
    }
}
