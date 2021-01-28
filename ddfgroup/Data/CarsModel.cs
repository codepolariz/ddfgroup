using System;
using System.ComponentModel.DataAnnotations;

namespace ddfgroup.Data
{
    public class CarsModel
    {


        [Key]
        public int CarsModelId { get; set; }

        [Required]
        [Display(Name = "Model Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Int32 Year { get; set; }


        public Brands Brands { get; set; }


        [Required]
        [Display(Name = "Brand Name")]
        public int BrandsId { get; set; }





    }
}
