using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ddfgroup.Data;
using System.Linq;
using System.Collections;

namespace ddfgroup.Pages
{
    public class NairaModel : PageModel
    {
     
        public ApplicationDbContext _Context;
        public Cars Cars { get; set; }
        public IEnumerable Images { get; set; }
        public PageContents Payment { get; set; }
        private protected int Interger { get; set; } = 6;
        //public string Content { get; set; }
        private string Details { get; set; } = "Details";
        private string Naira { get; set; } = "Naira";
        private Int64 Price { get; set; }
        private Currency Currency { get; set; }

        public NairaModel(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<IActionResult> OnGetNairaAsync(int cid, string handler)
        {

            Cars = await _Context.Cars
                 .Include(option => option.Brands)
                 .Include(option => option.Transmissions).FirstOrDefaultAsync(m => m.Id == cid);

            Images = _Context.CarImages.Where(a => a.CarsId == cid);
            ViewData["Details"] = Cars.OtherDetails;
            Payment = await _Context.PageInfo.FirstOrDefaultAsync(m => m.Id == Interger);
            ViewData["Content"] = Payment.PageContent;
            
               //var PriceInNaira = FindCurr().Result.BaseAmount * FindCurr().Result.ExchnageRateAmount;
             

            if (Cars == null)
            {
                return NotFound();
            }
            return Page();
        }


        private bool CarExist(int cid)
        {
            var Car = _Context.Cars.Find(cid);
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

            var result = await _Context.Cars.FirstOrDefaultAsync(c => c.Id == cid);
            //if(result==null)
            //{
            //    return NotFound();
            //}

            return result;
        }

        public int Calculate(int BaseAmount, int ExchangeRate)
        {
            
            return BaseAmount * ExchangeRate;

        }
    }
}
