using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly Northwind.Entities.Models.NorthwindContext _context;

        public IndexModel(Northwind.Entities.Models.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Northwind.Entities.Models.Employees> Employees { get;set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees
                .Include(e => e.ReportsToNavigation).ToListAsync();
        }
    }
}
