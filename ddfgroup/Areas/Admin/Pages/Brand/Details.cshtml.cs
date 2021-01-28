using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.Brand
{
    public class DetailsModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public DetailsModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Brands Brands { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Brands = await _context.Brands.FirstOrDefaultAsync(m => m.BrandsId == id);

            if (Brands == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
