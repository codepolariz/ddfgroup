using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ddfgroup.Pages
{
    public class ServicesModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public ServicesModel(ApplicationDbContext Context)
        {
            _context = Context;
        }

        [BindProperty]
        public PageContents PageContents { get; set; }
        public async Task<IActionResult> OnGet(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            PageContents = await _context.PageInfo.FindAsync(Id);
            ViewData["Content"] = PageContents.PageContent;

            if (PageContents == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
