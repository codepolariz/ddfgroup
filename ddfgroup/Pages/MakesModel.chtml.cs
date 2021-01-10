using ddfgroup.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddfgroup.Pages
{
    public class MakesModel
    {
        public readonly ApplicationDbContext _dbContext;

        public MakesModel(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        
     
        public async Task<dynamic> Makes(int brand)
        {
            //var data = _dbContext.CarsModel.FindAsync(brand);
            //if (data != null)
            //    return new ObjectResult(new { status = "done" });
            //else
            //    return new ObjectResult(new { StatusCode = "Failed" });

            return "ok";
        }
    }
}
