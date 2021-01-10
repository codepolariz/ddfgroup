using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ddfgroup.Data;

namespace ddfgroup.Areas.Admin.Pages.Automobile
{
    public class DeleteModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public DeleteModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cars Cars { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cars = await _context.Cars
                .Include(c => c.Brands)
                .Include(c => c.CarStatus)
                .Include(c => c.Transmissions).FirstOrDefaultAsync(m => m.Id == id);

            if (Cars == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cars = await _context.Cars.FindAsync(id);

            if (Cars != null)
            {
                _context.Cars.Remove(Cars);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
