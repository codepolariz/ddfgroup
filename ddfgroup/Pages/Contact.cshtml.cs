using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ddfgroup.Pages
{
    public class ContactModel : PageModel
    {
        public readonly ApplicationDbContext _Context;

        public ContactModel(ApplicationDbContext context)
        {
            _Context=context;
        }

        public PageContents PageContents { get; set; }
        public async Task<IActionResult>  OnGet(int? Id)
        {
            if(Id == null)
            {
                return NotFound();

            }

            PageContents=await _Context.PageInfo.FindAsync(Id);
            if(PageContents == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
