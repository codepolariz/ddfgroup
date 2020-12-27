using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ddfgroup.Areas.Identity.Pages.Account;
using ddfgroup.Data;

namespace ddfgroup.Areas.Admin.Pages.Dashboard
{
    public class ManageUsersModel : PageModel
    {
        private readonly ApplicationDbContext _Context;

        public IList<ApplicationUser> Users { get; set; }

        public ManageUsersModel(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public void OnGet()
        {
            Users = _Context.Users.ToList();

        }

        //public async Task<IActionResult> OnGetEditAsync(int Id)
        //{
        //    User = await _Context.User.FindAsync(Id);

        //    if (User == null)
        //    {
        //        return RedirectToPage("./ManageUser");
        //    }

        //    return Page();
        //}
    }
}
