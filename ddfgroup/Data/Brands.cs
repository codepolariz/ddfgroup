using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ddfgroup.Data
{
    public class Brands
    {

        [Key]
        public int BrandsId { get; set; }

        [Display(Name = "Brand Name")]
        [Required]
        public String Name { get; set; }

        public List<CarsModel> CarsModel { get; set; }

        public IList<Cars> Cars { get; set; }
    }
}
