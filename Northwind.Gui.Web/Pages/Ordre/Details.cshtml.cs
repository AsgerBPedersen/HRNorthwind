using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.DataAcess;
using Northwind.Entities.Models;
using Northwind.WebServices;
using Northwind.WebServices.Objects;

namespace Northwind.Gui.Web.Pages.Ordre
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _context;
        private ExchangeRates rates;
        [BindProperty(SupportsGet = true)]
        public string Selected { get; set; } = "USD";
        public decimal ExchangeRate { get; set; } = 1;
        public List<SelectListItem> Currencies { get; set; }
        public DetailsModel(IOrderService context)
        {
            rates = ExchangeRateService.GetRates();
            Currencies = new List<SelectListItem>()
            {
                new SelectListItem("USD", "USD"),
                new SelectListItem("DKK", "DKK"),
                new SelectListItem("EUR", "EUR"),
                new SelectListItem("GBP", "GBP"),
                new SelectListItem("CAD", "CAD")
            };
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

            if (rates != null)
            {
                switch (Selected)
                {
                    case "DKK":
                        ExchangeRate = (decimal)rates.rates.DKK;
                        break;
                    case "EUR":
                        ExchangeRate = (decimal)rates.rates.EUR;
                        break;
                    case "GBP":
                        ExchangeRate = (decimal)rates.rates.GBP;
                        break;
                    case "¨CAD":
                        ExchangeRate = (decimal)rates.rates.CAD;
                        break;
                }
            } else
            {
                Selected = "USD";
            }

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
            Invoices = await _context.GetInvoice((int)id);
            TotalPrice = Order.OrderDetails.Sum(o => o.Quantity * o.UnitPrice * (decimal)(1 - o.Discount));

            if (rates != null)
            {
                switch (Selected)
                {
                    case "DKK":
                        ExchangeRate = (decimal)rates.rates.DKK;
                        break;
                    case "EUR":
                        ExchangeRate = (decimal)rates.rates.EUR;
                        break;
                    case "GBP":
                        ExchangeRate = (decimal)rates.rates.GBP;
                        break;
                    case "¨CAD":
                        ExchangeRate = (decimal)rates.rates.CAD;
                        break;
                }
            }
            else
            {
                Selected = "USD";
            }
            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
