using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ddfgroup.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Drawing;
using System.Drawing.Imaging;

namespace ddfgroup.Areas.Admin.Pages.Automobile
{
    public class CreateModel : PageModel
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


        public CreateModel(ddfgroup.Data.ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
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


            return Page();
        }

        [BindProperty]
        public Cars Cars { get; set; }

         

        

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid)
            {
                this.Content("One or More Fields is invalid");
                
                return Page();
            }

            var ModelId = Cars.CarsModelId;
            var ModelName = _context.CarsModel.FindAsync(ModelId).Result;
             
            if (ModelName == null)
            {
                return NotFound();
            }

            if (FileUpload != null)
            {
                UploadFolder = "upload";
                WebRoot = _hostingEnvironment.WebRootPath;
                UploadDir = System.IO.Path.Combine(WebRoot, UploadFolder);
                

                if (!Directory.Exists(UploadDir))
                {
                    Directory.CreateDirectory(UploadDir);
                }
                //long size = FileUpload.Sum(f => f.Length);

                //Home file upload
                

                NewString = CreateRandomString();
                  
                FileName = ContentDispositionHeaderValue.Parse(FileUpload.ContentDisposition).FileName.Trim('"');
                Directory.CreateDirectory(UploadDir + "/" + NewString + "/" + "temp");
                DynamicImageFolder = System.IO.Path.Combine(UploadDir, NewString, "temp");
                var ImageFolder = UploadDir + "/"+ NewString;
                FileNameRenamed = GetUniqueFileName(FileName);     // store final final filename
                string FullPath = Path.Combine(DynamicImageFolder, FileNameRenamed);     // create dynamic string for unique folder
                FileType = System.IO.Path.GetExtension(FileName);
                if (FileUpload.Length > 0)
                {
                   
                    using (var stream = new FileStream(FullPath, FileMode.Create))
                    {
                        FileUpload.CopyTo(stream);
                        //await Task.Delay(100);
                        Resize("C:\dotnetcore\ddfgroup\ddfgroup\wwwroot\upload\86e3016b-16e1-4c\temp\2019-lexus-lx-570-002-f51479eb9d802f3409bef2_8d1a6.jpg", 200,200);
                    }
                }
            }

            if (MultipleFileUpload.Count>0 &&  MultipleFileUpload != null)
            {
                 NewThumbString = CreateRandomString();
                Directory.CreateDirectory(UploadDir + "/" + NewThumbString + "/" + "thumbs");
                int counter = 0;
                foreach (IFormFile ModelFile in MultipleFileUpload)    //Home file upload
                {

                ArrFileName = ContentDispositionHeaderValue.Parse(ModelFile.ContentDisposition).FileName.Trim('"');
                ThumbImageFolder = System.IO.Path.Combine(UploadDir , NewThumbString,"thumbs" );
                string FullPath = Path.Combine(ThumbImageFolder, GetUniqueFileName(ArrFileName));     // create dynamic string for unique folder
                //FileType = System.IO.Path.GetExtension(FileName);
                if (MultipleFileUpload.Count > 0)
                {
                    using (var stream = new FileStream(FullPath, FileMode.Create))
                    {
                            ModelFile.CopyTo(stream);
                    }
                }
                    counter++;
                 }

                Cars.ModelName = ModelName.Name;     // Map Cars ModelName Object to CarsModel Name Object
                Cars.Year = ModelName.Year;
                Cars.UploadedDate = DateTime.Now;
                Cars.DisplayFileName = FileNameRenamed;
                Cars.FolderName = NewString;
                Cars.ThumbFolderName = NewThumbString;
                Cars.ArrayFileName = ArrFileName;
                
                //Cars.ArrayFileName = ArrFileName.ToString(); //// check
                _context.Cars.Add(Cars);
                await _context.SaveChangesAsync();
                
                //-------------------------------- resize image

                Message = "Successful;";
                return RedirectToPage("./Index");
            }

                return this.Content("Failed");
            }

        private string GetUniqueFileName(string FName)
        {
            FName = Path.GetFileName(FName);
            return Path.GetFileNameWithoutExtension(FName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 5)
                      + Path.GetExtension(FName);
        }

        private string CreateRandomString()
        {
            return Guid.NewGuid().ToString().Substring(0, 16);
        }



        public static void Resize(string path, int nWidth, int nHeight)
        {
            using (var result = new Bitmap(nWidth, nHeight))
            {
                using (var input = new Bitmap(path))
                {
                    using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
                    {
                        g.DrawImage(input, 0, 0, nWidth, nHeight);
                    }
                }

                var ici = ImageCodecInfo.GetImageEncoders().FirstOrDefault(ie => ie.MimeType == "image/jpeg");
                var eps = new EncoderParameters(1);
                eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                result.Save(path, ici, eps);
            }
        }
    }
    


}
