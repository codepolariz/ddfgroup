using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ddfgroup.Areas.Admin.Pages.Automobile
{
    public class EditPrice  : ddfgroup.Data.Cars
    {
        [Required]
        [Display(Name="Price")]
        public string Price { get; set; }

        [Required]
        [Display(Name = "Price In Naira")]
        public string PriceNaira{ get; set; }
    }
}
