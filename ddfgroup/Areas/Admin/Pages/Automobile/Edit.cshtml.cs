using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ddfgroup.Data;

namespace ddfgroup.Areas.Admin.Pages.Automobile
{
    public class EditModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public EditModel(ddfgroup.Data.ApplicationDbContext context)
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
           ViewData["BrandsId"] = new SelectList(_context.Brands, "BrandsId", "Name");
           ViewData["CarStatusId"] = new SelectList(_context.CarStatus, "CarStatusId", "StatusName");
           ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionId", "TransmissionId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cars).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarsExists(Cars.Id))
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

        private bool CarsExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
