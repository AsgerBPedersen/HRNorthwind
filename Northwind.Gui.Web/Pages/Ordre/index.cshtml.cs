﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web.Pages.Ordre
{
    public class IndexModel : PageModel
    {
        private readonly Northwind.Entities.Models.NorthwindContext _context;

        public IndexModel(Northwind.Entities.Models.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation).ToListAsync();
        }
    }
}
