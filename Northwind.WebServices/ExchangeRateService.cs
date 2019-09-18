using Northwind.WebServices.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.WebServices
{
    public class ExchangeRateService : WebService
    {
        public static string Api { get; set; } = $"https://openexchangerates.org/api/latest.json?app_id=834120dd53d64daaa4df3af26cf509a4&base=USD&symbols=GBP,EUR,DKK,CAD";
        public static ExchangeRates GetRates()
        {
            
            var res = CallWebApi(Api);
            if (res != null)
            {
                return GetObject<ExchangeRates>(res);
            }
            return null;
        }

        public static ExchangeRates GetRates(string api)
        {

            var res = CallWebApi(api);
            if (res != null)
            {
                return GetObject<ExchangeRates>(res);
            }
            return null;
        }
    }
}
