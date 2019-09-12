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
        private readonly IEmployeeService _context;

        public EditModel(IEmployeeService context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.GetById((int)id);
            if (Employee == null)
            {
                return NotFound();
            }
           ViewData["ReportsTo"] = new SelectList(await _context.GetEmployees(), "EmployeeId", "FirstName");
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int? id, int? employmentId)
        {
            if (id == null && employmentId == null)
            {
                return NotFound();
            }
            await _context.DeleteEmployment((int)id, (int)employmentId);
            return RedirectToPage("/HR/Employees/edit", new { id = (int)id });
        }

        public async Task<IActionResult> OnPostAddEmploymentAsync()
        {
            var newEmp = new Employment() { HireDate = DateTime.Now.Date };
            Employee.Employments.Add(newEmp);
            TryValidateModel(Employee);
            if (!ModelState.IsValid)
            {
                ViewData["ReportsTo"] = new SelectList(await _context.GetEmployees(), "EmployeeId", "FirstName");
                Employee.Employments.Remove(newEmp);
                return Page();
            }

            await _context.UpdateEmployee(Employee);

            return RedirectToPage("/HR/Employees/edit", new { id = Employee.EmployeeId });
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ReportsTo"] = new SelectList(await _context.GetEmployees(), "EmployeeId", "FirstName");
                return Page();
            }

            await _context.UpdateEmployee(Employee);

            return RedirectToPage("./Index");
        }
    }
}
