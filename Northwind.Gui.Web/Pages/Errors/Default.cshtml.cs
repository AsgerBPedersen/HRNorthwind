using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Northwind.Gui.Web.Pages.Errors
{
    public class DefaultModel : PageModel
    {
        public string Message { get; set; }
        public IActionResult OnGet()
        {
            // Retrieve error information in case of internal errors
            var error = HttpContext
                      .Features
                      .Get<IExceptionHandlerFeature>();
            if (error == null)
                return Page();

            // Use the information about the exception 
            Message = error.Error.Message;
            return Page();

        }
    }
}