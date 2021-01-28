using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.TransmissionTypes
{
    public class DetailsModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public DetailsModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Transmission Transmission { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transmission = await _context.Transmissions.FirstOrDefaultAsync(m => m.TransmissionId == id);

            if (Transmission == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
