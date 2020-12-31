using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ddfgroup.Data;

namespace ddfgroup.Areas.Admin.Pages.AutoModels
{
    public class DeleteModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public DeleteModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarsModel CarsModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarsModel = await _context.CarsModels
                .Include(c => c.Brands).FirstOrDefaultAsync(m => m.Id == id);

            if (CarsModel == null)
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

            CarsModel = await _context.CarsModels.FindAsync(id);

            if (CarsModel != null)
            {
                _context.CarsModels.Remove(CarsModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
