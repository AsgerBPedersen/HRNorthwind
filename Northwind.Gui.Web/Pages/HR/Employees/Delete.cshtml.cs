using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.DataAcess;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _context;

        public DeleteModel()
        {
            _context = new EmployeeRepository();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = _context.GetEmployeeById((int)id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = _context.GetEmployeeById((int)id);

            if (Employee != null)
            {
                _context.DeleteEmployee(Employee);
            }

            return RedirectToPage("./Index");
        }
    }
}
