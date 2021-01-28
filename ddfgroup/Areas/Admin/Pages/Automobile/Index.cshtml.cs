using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.Automobile
{
    public class IndexModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public IndexModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cars> Cars { get; set; }

        public async Task OnGetAsync()
        {
            Cars = await _context.Cars
                .Include(c => c.Brands)
                .Include(c => c.CarStatus)
                .Include(c => c.Transmissions).ToListAsync();

        }
    }
}
