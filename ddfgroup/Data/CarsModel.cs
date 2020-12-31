using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ddfgroup.Data
{
    public class CarsModel
    {   

      


        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }


        public Brands Brands { get; set; }


        [ForeignKey("FKBrandId")]
        [Required]
        [Display(Name ="Brands")]
        public int BrandsId { get; set; }


    }
}
