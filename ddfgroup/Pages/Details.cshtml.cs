using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;

namespace ddfgroup.Pages
{
    public class DetailsModel : PageModel
    {
        public ApplicationDbContext _Context;

        public Cars Cars { get; set; }
        public IEnumerable Images { get; set; }
        public PageContents Payment { get; set; }
        private protected int Interger { get; set; } = 5;
        public string Content { get; set; }
        private string Details { get; set; } = "Details";
        private string Naira { get; set; } = "Naira";
        private Int64 Price { get; set; }
        private Currency Currency { get; set; }
      

        public DetailsModel(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<IActionResult> OnGetDetailsAsync(int cid, string handler)
        {

            Cars = await _Context.Cars
                 .Include(option => option.Brands)
                 .Include(option => option.Transmissions).FirstOrDefaultAsync(m => m.Id == cid);

              Images = _Context.CarImages.Where(a=>a.CarsId == cid);

            ViewData["Details"] = Cars.OtherDetails;
            Payment = await _Context.PageInfo.FirstOrDefaultAsync(m => m.Id == Interger);
            ViewData["Content"] = Payment.PageContent;
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
    }
}
