using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Northwind.Entities.Models
{
    public partial class Employee : IEntityWithId
    {

        public Employee()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
            Employments = new HashSet<Employment>().ToList();
            InverseReportsToNavigation = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        [DisplayName("Efternavn")]
        [Required(ErrorMessage = "Du skal skrive et navn")]
        [RegularExpression("[a-zA-ZÆØÅæøå ]+", ErrorMessage = "Navn kan ikke indeholde andet en bogstaver")]
        [MaxLength(20, ErrorMessage = "Efternavn kan ikke være længere end 4.")]
        public string LastName { get; set; }
        [DisplayName("Fornavn")]
        [Required(ErrorMessage = "Du skal skrive et navn")]
        [RegularExpression("[a-zA-ZÆØÅæøå ]+", ErrorMessage = "Navn kan ikke indeholde andet en bogstaver")]
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
        [DisplayName("By")]
        [MaxLength(15, ErrorMessage = "By kan ikke være længere end 15.")]
        public string City { get; set; }
        [DisplayName("Region")]
        [MaxLength(15, ErrorMessage = "Region  kan ikke være længere end 15.")]
        public string Region { get; set; }
        [DisplayName("Postnummer")]
        [MaxLength(10, ErrorMessage = "Postnummer kan ikke være længere end 10.")]
        public string PostalCode { get; set; }
        [DisplayName("Land")]
        [MaxLength(15, ErrorMessage = "Land kan ikke være længere end 15.")]
        public string Country { get; set; }
        [MaxLength(24, ErrorMessage = "Nummer kan ikke være længere end 24.")]
        [DisplayName("Hjemme telefon")]
        public string HomePhone { get; set; }
        [DisplayName("Område kode")]
        [MaxLength(4, ErrorMessage = "Område kode kan ikke være længere end 4.")]
        public string Extension { get; set; }
        [DisplayName("Foto")]
        public byte[] Photo { get; set; }
        [DisplayName("Noter")]
        public string Notes { get; set; }
        [DisplayName("Raportere til")]
        public int? ReportsTo { get; set; }
        [DisplayName("Foto sti")]
        public string PhotoPath { get; set; }
        [DisplayName("Initialer")]
        [MaxLength(4, ErrorMessage = "Initialer kan ikke være længere end 4.")]
        public string Initials { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Arbejdstelefon")]
        [MaxLength(24, ErrorMessage = "Nummer kan ikke være længere end 24.")]
        public string WorkPhone { get; set; }
        [DisplayName("Rapportere til")]
        public virtual Employee ReportsToNavigation { get; set; }
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        [ValidateDates(ErrorMessage = "Datoer må ikke overlappe")]
        public virtual IList<Employment> Employments { get; set; }
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public int Id => EmployeeId;

        public bool EmploymentValidation(Employment employment)
        {
            if (Employments.SingleOrDefault(e => e.HireDate < (employment.LeaveDate == null ? DateTime.Now : employment.LeaveDate) && employment.HireDate < (e.LeaveDate == null ? DateTime.Now : e.LeaveDate) || e.LeaveDate == null && employment.LeaveDate == null) != null)
            {
                return false;
            }
            return true;
        }
    }
}
