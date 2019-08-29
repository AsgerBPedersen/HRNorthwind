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
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _context;

        public EditModel(IEmployeeRepository context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]
        public List<Employment> Employments { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = _context.GetEmployeeById((int)id);
            Employments = Employee.Employments.ToList();
            if (Employee == null)
            {
                return NotFound();
            }
           ViewData["ReportsTo"] = new SelectList(_context.GetEmployees(), "EmployeeId", "FirstName");
            return Page();
        }

        public IActionResult OnGetDelete(int? id, int? employmentId)
        {
            if (id == null && employmentId == null)
            {
                return NotFound();
            }
            _context.DeleteEmployment((int)id, (int)employmentId);
            return RedirectToPage("/HR/Employees/edit", new { id = (int)id });
        }

        public IActionResult OnGetAddEmployment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _context.AddEmployment((int)id);
            return RedirectToPage("/HR/Employees/edit", new { id = (int)id });
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Employee).State = EntityState.Modified;
            Employee.Employments = Employments;
            _context.UpdateEmployee(Employee);

            return RedirectToPage("./Index");
        }
    }
}
