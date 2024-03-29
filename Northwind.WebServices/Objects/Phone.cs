﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.WebServices.Objects
{
    public class Phone
    {
        public bool valid { get; set; }
        public string number { get; set; }
        public string local_format { get; set; }
        public string international_format { get; set; }
        public string country_prefix { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string location { get; set; }
        public string carrier { get; set; }
        public string line_type { get; set; }
    }
}
