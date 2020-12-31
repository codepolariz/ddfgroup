using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ddfgroup.Data
{
    public class Brands 
    {    
        
        [Key]
        public int Id { get; set; }

        [Display(Name="Brand Name")]
        [Required]
        public  String Name { get; set; }

        public List<CarsModel> CarsModels { get; set; }
    }
}
