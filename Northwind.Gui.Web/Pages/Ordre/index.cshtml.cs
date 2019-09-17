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
    public class IndexModel : PageModel
    {
        private readonly IOrderService _context;

        public IndexModel(IOrderService context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.GetOrders();
        }

        public async Task OnGetNextShipmentsAsync()
        {
            Order = await _context.GetNextShipments();
        }
    }
}
