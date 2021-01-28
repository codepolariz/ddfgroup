using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.Content
{
    public class IndexModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public IndexModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PageContents> PageContents { get; set; }

        public async Task OnGetAsync()
        {
            PageContents = await _context.PageInfo.ToListAsync();
        }
    }
}
