using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.AutoModels
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
            ViewData["BrandsId"] = new SelectList(_context.Brands, "BrandsId", "Name");

            return Page();
        }

        [BindProperty]
        public CarsModel CarsModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CarsModel.Year = CarsModel.Date.Year;
            _context.CarsModel.Add(CarsModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
