using ddfgroup.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ddfgroup.Areas.Admin.Pages.Automobile
{
    public class EditModel : PageModel
    {
        private readonly ddfgroup.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        [BindProperty]
        [Display(Name = "Image Upload")]
        public IFormFile FileUpload { get; set; }

        [BindProperty]
        [Display(Name = "Multiple Cars Upload")]
        public IList<IFormFile> MultipleFileUpload { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FullPath { get; set; }
        public string UploadFolder { get; set; }
        public string WebRoot { get; set; }
        public string UploadDir { get; set; }
        public string ThumbImageFolder { get; set; }
        public string DynamicImageFolder { get; set; }
        public string NewString { get; set; }
        public string ArrFileName { get; set; }
        public string NewThumbString { get; set; }
        public string Message { get; set; }
        public string FileNameRenamed { get; set; }
        public string NewFileString { get; set; }
        private int Cid { get; set; }
        [BindProperty]
        public Cars Cars { get; set; }

        public EditModel(ddfgroup.Data.ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {

            ViewData["BrandsId"] = new SelectList(_context.Brands, "BrandsId", "Name").OrderBy(option => option.Text); ;
            ViewData["CarsModelId"] = new SelectList(_context.CarsModel, "CarsModelId", "Name").OrderBy(option => option.Text); ;
            ViewData["CarStatusId"] = new SelectList(_context.CarStatus, "CarStatusId", "StatusName").OrderBy(option => option.Text); ;
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionId", "Name").OrderBy(option => option.Text); ;

            var Doors = new List<SelectListItem> {
            new SelectListItem() { Value = "4-Doors", Text = "4 Doors" },
            new SelectListItem() { Value = "2-Doors", Text = "2 Dorrs" },
            new SelectListItem() { Value = "6-Doors", Text = "6 Doors" }
              };
            ViewData["Doors"] = Doors;

            var Title = new List<SelectListItem> {
            new SelectListItem() { Value = "Clean Title", Text = "Clean Title" },
            new SelectListItem() { Value = "Salvage Title", Text = "Salvage Title" },
            new SelectListItem() { Value = "Rebuild Title", Text = "Rebuild Title" }
              };
            ViewData["CarTitle"] = Title;

            var Cylinder = new List<SelectListItem> {
            new SelectListItem() { Value = "4 Cylinder", Text = "4 Cylinder" },
            new SelectListItem() { Value = "6 Cylinder", Text = "6 Cylinder" },
            new SelectListItem() { Value = "8 Cylinder", Text = "8 Cylinder" }
              };
            ViewData["Cylinder"] = Cylinder;

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
            ViewData["BrandsId"] = new SelectList(_context.Brands, "BrandsId", "Name");
            ViewData["CarStatusId"] = new SelectList(_context.CarStatus, "CarStatusId", "StatusName");
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionId", "Name");

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



            _context.Attach(Cars).State = EntityState.Modified;
            var ModelId = Cars.CarsModelId;
            var cid = Cars.Id;
            var ModelName = _context.CarsModel.FindAsync(ModelId).Result;
            Cars = _context.Cars.FindAsync(cid).Result;

            if (FileUpload == null && MultipleFileUpload.Count == 0)
            {
                Cars.DisplayFileName = Cars.DisplayFileName;
                Cars.FolderName = Cars.FolderName;
                Cars.ArrayFileName = Cars.ArrayFileName;
                Cars.ThumbFolderName = Cars.ThumbFolderName;

                //_context.Remove(Cars.ThumbFolderName).State = EntityState.Detached;
                //_context.Remove(Cars.FolderName).State = EntityState.Detached;
                //_context.Remove(Cars.ArrayFileName).State = EntityState.Detached;
                //_context.Remove(Cars.DisplayFileName).State = EntityState.Detached;
            }

            try  // process properties or fields changes to database
            {
                Cars.ModelName = ModelName.Name;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    ModelState.AddModelError("", "Unable to save changes.Try again, and if the problem persists, see your system administrator.");
                
            
            }

            return RedirectToPage("./Index");
        }

        private bool CarsExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
