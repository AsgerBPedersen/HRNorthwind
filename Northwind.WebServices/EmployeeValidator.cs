using Northwind.WebServices.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.WebServices
{
    public class EmployeeValidator : WebService
    {
        public static bool EmailValidation(string s)
        {
            string api = $"https://api.debounce.io/v1/?api=5d79f58e8cfaa&email={s}";

            Email res = GetObject<Email>(CallWebApi(api));

            if (res.debounce.code == "5")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidatePhone(string number)
        {
            string api = $"http://apilayer.net/api/validate?access_key=582a1d7a4d70b43d537ff5d51ce582ca&number={number}&format=1";

            Phone res = GetObject<Phone>(CallWebApi(api));

            return res.valid;
        }

        public static bool ValidateAdress(string street, string city)
        {
            string api = $"https://us-street.api.smartystreets.com/street-address?auth-id=9fe8a418-98c7-2be9-9345-71e4a8bea3d8&auth-token=Ut36GYp0XJyD7DDMgkY5&street={street.Replace(" ", "+")}&city={city.Replace(" ", "+")}";

            string s = CallWebApi(api);
            if (s == "[]")
            {
                return false;
            }

            return true;
        }

        public static (bool isValid, List<string> errors) ValidateProfanity(string s)
        {
            string api = $"https://www.purgomalum.com/service/json?text={s}";

            Profanity res = GetObject<Profanity>(CallWebApi(api));

            List<string> errors = new List<string>();
            string[] input = s.Split(' ');
            string[] output = res.result.Split(' ');
            for (int i = 0; i < input.Length; i++)
            {
                string dif = string.Join("", input[i].ToArray().Where(item => !output[i].Contains(item.ToString())).ToArray());
                if (dif.Length > 0)
                {
                    errors.Add(dif);
                }
            }
            if (errors.Count == 0)
            {
                return (true, errors);
            }
            return (false, errors);
        }
        
    }
}
