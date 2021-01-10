using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ddfgroup.Data;

namespace ddfgroup.Areas.Admin.Pages.Status
{
    public class DeleteModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public DeleteModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarStatus CarStatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarStatus = await _context.CarStatus.FirstOrDefaultAsync(m => m.CarStatusId == id);

            if (CarStatus == null)
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

            CarStatus = await _context.CarStatus.FindAsync(id);

            if (CarStatus != null)
            {
                _context.CarStatus.Remove(CarStatus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
