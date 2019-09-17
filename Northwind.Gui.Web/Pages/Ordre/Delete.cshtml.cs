using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.DataAcess;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web.Pages.Ordre
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderService _context;

        public DeleteModel(IOrderService context)
        {
            _context = context;
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.GetById((int)id);

            if (Order != null)
            {

                await _context.DeleteOrder(Order);
            }

            return RedirectToPage("./Index");
        }
    }
}
