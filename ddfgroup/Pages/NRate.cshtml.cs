using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ddfgroup.Pages
{
    public class NRateModel : PageModel
    {
        public ApplicationDbContext _Context;

        public Cars Cars { get; set; }
        public PageContents Payment { get; set; }
        private protected int Interger { get; set; } = 5;
        //public string Content { get; set; }
        private string Details { get; set; } = "Details";
        private string Naira { get; set; } = "Naira";
        private Int64 Price { get; set; }
        private Currency Currency { get; set; }

        public NRateModel(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<IActionResult> OnGetNRateAsync(int cid, string handler)
        {

            Cars = await _Context.Cars
                 .Include(option => option.Brands)
                 .Include(option => option.Transmissions).FirstOrDefaultAsync(m => m.Id == cid);

           
                ViewData["Details"] = Cars.OtherDetails;
                Payment = await _Context.PageInfo.FirstOrDefaultAsync(m => m.Id == Interger);
                ViewData["Content"] = Payment.PageContent;
                //int ConvertedPrice = int.TryParse(CarPrice(cid).Result.Price,
                //    System.Globalization.NumberStyles.AllowThousands|
                //    System.Globalization.NumberStyles.AllowDecimalPoint|
                //    System.Globalization.NumberStyles.AllowCurrencySymbol,null,out int Result);
                // var PriceInNaira = Calculate(Currency.BaseAmount * FindCurr().Result.ExchnageRateAmount);
                // ViewBag["PriceInNaira"] = ConvertedPrice * PriceInNaira;

                return Page();
            }


        private bool CarExist(int id)
        {
            var Car = _Context.Cars.Find(id);
            if (Car != null)
            {
                return true;
            }
            else
                return false;
        }
        private async Task<Currency> FindCurr()
        {
            return await _Context.Currencies.FirstOrDefaultAsync(c => c.BaseCurrency == "USD");

        }
        private async Task<Cars> CarPrice(int cid)
        {
            return await _Context.Cars.FirstOrDefaultAsync(c => c.Id == cid);

        }

        public int Calculate(int BaseAmount, int ExchangeRate)
        {
            return BaseAmount * ExchangeRate;

        }
    }
}
