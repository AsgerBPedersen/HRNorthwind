using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Northwind.WebServices
{
    public class WebService
    {
        protected static string CallWebApi(string s)
        {
            string res;
            using (WebClient client = new WebClient())
            {
                try
                {
                    res = client.DownloadString(s);
                }
                catch (Exception)
                {

                    res = null;
                }
            }
            return res;
        }

        protected static T GetObject<T>(string s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }
    }
}
