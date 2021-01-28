using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddfgroup.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ddfgroup.Areas.Admin.Pages.Automobile
{
    public class EditPriceModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EditPriceModel(ddfgroup.Data.ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        [BindProperty]
        public Cars Cars { get; set; }
        public EditPrice EditCarPrice { get; set; }
        public async Task<IActionResult> OnGetAsync(int? cid)
        {
            if (cid == null)
            {
                return NotFound();
            }

            Cars = await _context.Cars
                .Include(c => c.Brands)
                .Include(c => c.CarStatus)
                .Include(c => c.Transmissions).FirstOrDefaultAsync(m => m.Id == cid);

            if (Cars == null)
            {
                return NotFound();
            }

            return Page();
        }
       
        public async Task<IActionResult> OnPostAsync()
        {
            
            
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var data = await _context.Cars.FindAsync(Cars.Id);

            _context.Attach(data).State = EntityState.Modified;

            try
            {
            
                data.Price = Cars.Price;
                data.PriceNaira = Cars.PriceNaira;
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {

                if (!CarExists(Cars.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return RedirectToPage("./Index");
        }

        public bool CarExists(int id)
        {
           return  _context.Cars.Any(e => e.Id == id);
        }
    }
}
