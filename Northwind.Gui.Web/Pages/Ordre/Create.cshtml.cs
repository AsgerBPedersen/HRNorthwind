using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.DataAcess;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web.Pages.Ordre
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService _context;
        private readonly IEmployeeService _emps;

        public CreateModel(IOrderService context, IEmployeeService emps)
        {
            _context = context;
            _emps = emps;
        }

        public async Task<IActionResult> OnGet()
        {
        ViewData["CustomerId"] = new SelectList(await _context.GetCustomers(), "CustomerId", "CustomerId");
        ViewData["EmployeeId"] = new SelectList(await _emps.GetEmployees(), "EmployeeId", "FirstName");
        ViewData["ShipVia"] = new SelectList(await _context.GetShippers(), "ShipperId", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.AddOrder(Order);

            return RedirectToPage("./Index");
        }
    }
}