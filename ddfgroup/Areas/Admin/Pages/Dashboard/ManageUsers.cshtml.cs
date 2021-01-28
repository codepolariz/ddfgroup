using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

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
