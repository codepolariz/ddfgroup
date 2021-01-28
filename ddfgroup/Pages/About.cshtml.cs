using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ddfgroup.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public AboutModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PageContents PageContents { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PageContents = await _context.PageInfo.FirstOrDefaultAsync(m => m.Id == id);
            ViewData["Content"] = PageContents.PageContent;

            if (PageContents == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
