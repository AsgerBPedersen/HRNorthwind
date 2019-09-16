using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.DataAcess;
using Northwind.Entities.Models;
using Northwind.WebServices;

namespace Northwind.Gui.Web.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeService _context;

        public CreateModel(IEmployeeService context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["ReportsTo"] = new SelectList(await _context.GetEmployees(), "Id", "FirstName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.AddEmployee(Employee);

            return RedirectToPage("./Index");
        }
    }
}