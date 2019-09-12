using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.WebServices.Objects
{
    public class Debounce
    {
        public string email { get; set; }
        public string code { get; set; }
        public string role { get; set; }
        public string free_email { get; set; }
        public string result { get; set; }
        public string reason { get; set; }
        public string send_transactional { get; set; }
    }

    public class Email
    {
        public Debounce debounce { get; set; }
        public string success { get; set; }
        public string balance { get; set; }
    }
}
