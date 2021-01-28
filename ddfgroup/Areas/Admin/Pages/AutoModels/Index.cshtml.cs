using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.AutoModels
{
    public class IndexModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public IndexModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CarsModel> CarsModel { get; set; }

        public async Task OnGetAsync()
        {
            CarsModel = await _context.CarsModel
                .Include(c => c.Brands).ToListAsync();
        }
    }
}
