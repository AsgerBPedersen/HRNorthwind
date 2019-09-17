using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web.Pages.Ordre
{
    public class DetailsModel : PageModel
    {
        private readonly Northwind.Entities.Models.NorthwindContext _context;

        public DetailsModel(Northwind.Entities.Models.NorthwindContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation).FirstOrDefaultAsync(m => m.OrderId == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
