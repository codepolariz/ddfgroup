﻿using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.Comments
{
    public class DetailsModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;

        public DetailsModel(ddfgroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Feedback Feedback { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Feedback = await _context.Feedback.FirstOrDefaultAsync(m => m.Id == id);

            if (Feedback == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
