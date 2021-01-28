using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace ddfgroup.Areas.Admin.Pages.Automobile
{
    public class DeleteModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;
        [System.Obsolete]
        private readonly Microsoft.Extensions.Hosting.IHostEnvironment _hostEnvironment;
        public string WebRoot { get; set; }
      

        [System.Obsolete]
        public DeleteModel(ddfgroup.Data.ApplicationDbContext context, Microsoft.Extensions.Hosting.IHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [BindProperty]
        public Cars Cars { get; set; }
       

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cars = await _context.Cars
                .Include(c => c.Brands)
                .Include(c => c.CarStatus)
                .Include(c => c.Transmissions).FirstOrDefaultAsync(m => m.Id == id);

            if (Cars == null)
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

            Cars = await _context.Cars.FindAsync(id);
            var Img = _context.CarImages.Where(a => a.CarsId == id);

            if (Cars != null  && Cars.FolderName !=null)
            {
                _context.Cars.Remove(Cars);
                foreach(var imgs in Img)
                {
                    _context.CarImages.Remove(imgs);
                }

                var UploadFolder = "wwwroot\\upload";            
                var WebRoot = _hostEnvironment.ContentRootPath;
                var UploadDir = System.IO.Path.Combine(WebRoot, UploadFolder);

                Directory.Delete(UploadDir + "/"+Cars.FolderName, recursive: true);
                Directory.Delete(UploadDir + "/" + Cars.ThumbFolderName, recursive: true);
                await _context.SaveChangesAsync();
            }
            if(Cars != null  && Cars.FolderName == null)
            {
                _context.Cars.Remove(Cars);
                foreach (var imgs in Img)
                {
                    _context.CarImages.Remove(imgs);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
