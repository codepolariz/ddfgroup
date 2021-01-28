using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.Content
{
    public class EditModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public EditModel(ddfgroup.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PageContents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageContentsExists(PageContents.Id))
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

        private bool PageContentsExists(int id)
        {
            return _context.PageInfo.Any(e => e.Id == id);
        }
    }
}
