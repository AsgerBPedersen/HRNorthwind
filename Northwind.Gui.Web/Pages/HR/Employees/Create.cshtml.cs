using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.DataAcess;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeService _context;

        public CreateModel(IEmployeeService context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ReportsTo"] = new SelectList(_context.GetEmployees(), "EmployeeId", "FirstName");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AddEmployee(Employee);

            return RedirectToPage("./Index");
        }
    }
}