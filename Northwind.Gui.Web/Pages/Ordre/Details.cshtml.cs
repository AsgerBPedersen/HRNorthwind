using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.DataAcess;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web.Pages.Ordre
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _context;

        public DetailsModel(IOrderService context)
        {
            _context = context;
        }

        public Order Order { get; set; }
        public decimal TotalPrice { get; set; }
        public IList<Invoice> Invoices { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.GetById((int)id);
            Invoices = await _context.GetInvoice((int)id);
            TotalPrice = Order.OrderDetails.Sum(o => o.Quantity * o.UnitPrice * (decimal)(1 - o.Discount));
            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
