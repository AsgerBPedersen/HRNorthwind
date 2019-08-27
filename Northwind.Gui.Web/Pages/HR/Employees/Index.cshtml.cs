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

        public IndexModel()
        {
            _context = new EmployeeRepository();
        }

        public IList<Employee> Employee { get;set; }
        

        public void OnGet(string country, string title)
        {
            ViewData["country"] = country;
            ViewData["employmentTitle"] = title;
            Employee = _context.GetEmployeesByCountryAndEmployment(country, title);
           
        }
    }
}
