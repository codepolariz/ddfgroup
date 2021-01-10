using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ddfgroup.Data;

namespace ddfgroup.Areas.Admin.Pages.Status
{
    public class DetailsModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public DetailsModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public CarStatus CarStatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarStatus = await _context.CarStatus.FirstOrDefaultAsync(m => m.CarStatusId == id);

            if (CarStatus == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
