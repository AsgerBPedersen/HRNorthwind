using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly Northwind.Entities.Models.NorthwindContext _context;

        public CreateModel(Northwind.Entities.Models.NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ReportsTo"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}