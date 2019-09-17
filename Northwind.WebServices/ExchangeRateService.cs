using Northwind.WebServices.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.WebServices
{
    public class ExchangeRateService : WebService
    {
       public static ExchangeRates GetRates()
        {
            string api = $"https://openexchangerates.org/api/latest.json?app_id=834120dd53d64daaa4df3af26cf509a4&symbols=GBP,EUR,DDK,CAD";

            return GetObject<ExchangeRates>(CallWebApi(api));
        }
    }
}
