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

namespace Northwind.Gui.Web.Pages.Ordre
{
    public class EditModel : PageModel
    {
        private readonly IOrderService _context;
        private readonly IEmployeeService _emps;

        public EditModel(IOrderService context, IEmployeeService emps)
        {
            _context = context;
            _emps = emps;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.GetById((int)id);

            if (Order == null)
            {
                return NotFound();
            }
           ViewData["CustomerId"] = new SelectList(await _context.GetCustomers(), "CustomerId", "CustomerId");
           ViewData["EmployeeId"] = new SelectList(await _emps.GetEmployees(), "EmployeeId", "FirstName");
           ViewData["ShipVia"] = new SelectList(await _context.GetShippers(), "ShipperId", "CompanyName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.UpdateOrder(Order);

            return RedirectToPage("./Index");
        }


        public async Task<IActionResult> OnPostAddOrderDetailAsync()
        {
            var newDetail = new OrderDetail();
            Order.OrderDetails.Add(newDetail);
            //TryValidateModel(Employee);
            if (!ModelState.IsValid)
            {
                ViewData["CustomerId"] = new SelectList(await _context.GetCustomers(), "CustomerId", "CustomerId");
                ViewData["EmployeeId"] = new SelectList(await _emps.GetEmployees(), "EmployeeId", "FirstName");
                ViewData["ShipVia"] = new SelectList(await _context.GetShippers(), "ShipperId", "CompanyName"); ;
                Order.OrderDetails.Remove(newDetail);
                return Page();
            }

            await _context.UpdateOrder(Order);

            return RedirectToPage("/HR/Employees/edit", new { id = Order.OrderId });
        }


    }
}
