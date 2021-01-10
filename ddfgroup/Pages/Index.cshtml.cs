using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddfgroup.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        
        public IList<Cars> CarList { get; set; }

        [BindProperty]
         public string Brands { get; set; }   
        private int data  { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext Context)
        {
            //_logger = logger;
            _dbContext = Context;
        }

        public  async Task  OnGetAsync()
        {
            CarList = await _dbContext.Cars.ToListAsync();
            ViewData["Brands"] = new SelectList(_dbContext.Brands, "BrandsId", "Name").OrderBy(option=>option.Text);
           
        }



        
        public IActionResult Makes()
        {
            //var data = _dbContext.CarsModel.FindAsync(brand);
            //if (data != null)
            //    return new ObjectResult(new { status = "done" });
            //else
            //    return new ObjectResult(new { StatusCode = "Failed" });

            return new ObjectResult(new { StatusCode = "Failed" });
        }
    }
}
