using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.ExchangeRate
{
    public class CreateModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;


        public CreateModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Dictionary dic = new Dictionary();
            var list = dic.CurrencyCountries().ToList();
            SelectList select = new SelectList(list, "Key", "Value");
            ViewData["Country"] = select;
            var dicrate = dic.ExchangeCountries().ToList();
            SelectList sel = new SelectList(dicrate, "Key", "Value");
            ViewData["Rate"] = sel;
            return Page();
        }

        [BindProperty]
        public Currency Currency { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Currencies.Add(Currency);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
