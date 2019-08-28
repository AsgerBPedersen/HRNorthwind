using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.DataAcess;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository _context;

        public IndexModel(IEmployeeRepository context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }
        

        public void OnGet(string country, string title, string region, string firstName, string lastName)
        {
            ViewData["country"] = country;
            ViewData["employmentTitle"] = title;
            ViewData["region"] = region;
            ViewData["firstName"] = firstName;
            ViewData["lastName"] = lastName;
            Employee = _context.GetEmployeesFiltered(string.IsNullOrEmpty(country) ? "": country, string.IsNullOrEmpty(title) ? "" : title, string.IsNullOrEmpty(region) ? "" : region, string.IsNullOrEmpty(firstName) ? "" :firstName, string.IsNullOrEmpty(lastName) ? "" : lastName);
           
        }
    }
}
