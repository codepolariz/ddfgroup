using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.Content
{
    public class DeleteModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public DeleteModel(ddfgroup.Data.ApplicationDbContext context)
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

            if (PageContents == null)
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

            PageContents = await _context.PageInfo.FindAsync(id);

            if (PageContents != null)
            {
                _context.PageInfo.Remove(PageContents);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
