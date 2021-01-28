using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.ExchangeRate
{
    public class EditModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public EditModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Currency Currency { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Currency = await _context.Currencies.FirstOrDefaultAsync(m => m.CurrencyId == id);

            if (Currency == null)
            {
                return NotFound();
            }
            Dictionary dic = new Dictionary();
            var list = dic.CurrencyCountries().ToList();
            SelectList select = new SelectList(list, "Key", "Value");
            ViewData["Country"] = select;
            var dicrate = dic.ExchangeCountries().ToList();
            SelectList sel = new SelectList(dicrate, "Key", "Value");
            ViewData["Rate"] = sel;
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

            _context.Attach(Currency).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(Currency.CurrencyId))
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

        private bool CurrencyExists(long id)
        {
            return _context.Currencies.Any(e => e.CurrencyId == id);
        }
    }
}
