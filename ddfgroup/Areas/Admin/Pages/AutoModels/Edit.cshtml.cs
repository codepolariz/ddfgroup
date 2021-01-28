using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.AutoModels
{
    public class EditModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public EditModel(ddfgroup.Data.ApplicationDbContext context)
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

            CarsModel = await _context.CarsModel
                .Include(c => c.Brands).FirstOrDefaultAsync(m => m.CarsModelId == id);

            if (CarsModel == null)
            {
                return NotFound();
            }
            ViewData["BrandsId"] = new SelectList(_context.Brands, "BrandsId", "Name");
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

            _context.Attach(CarsModel).State = EntityState.Modified;
            CarsModel.Year = CarsModel.Date.Year;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarsModelExists(CarsModel.CarsModelId))
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarsModelExists(int id)
        {
            return _context.CarsModel.Any(e => e.CarsModelId == id);
        }
    }
}
