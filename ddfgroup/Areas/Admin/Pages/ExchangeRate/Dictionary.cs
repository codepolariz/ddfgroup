using System.Collections.Generic;

namespace ddfgroup.Areas.Admin.Pages.ExchangeRate
{
    public class Dictionary
    {

        public Dictionary<string, string> CurrencyCountries()
        {
            Dictionary<string, string> Country = new Dictionary<string, string>();

            Country.Add("USD", "America USA");
            Country.Add("CUSD", "Canada");

            return Country;

        }

        public Dictionary<string, string> ExchangeCountries()
        {
            Dictionary<string, string> RateCountry = new Dictionary<string, string>();
            RateCountry.Add("Nigeria", "Nigeria");
            return RateCountry;

        }
    }
}
