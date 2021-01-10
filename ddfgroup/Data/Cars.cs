using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ddfgroup.Data
{
    public class Cars   
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Car Name")]
        [Required(ErrorMessage ="Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Price Required")]
        public string Price { get; set; }

        [Display(Name="Car Title")]
        [Required(ErrorMessage ="Car Title is Required")]
        public string CarTitle { get; set; }

        [Required(ErrorMessage ="Mileage is Required")]
        public string Mileage { get; set; }

        [Required(ErrorMessage ="Required")]
        public string Cylinder { get; set; }

        [Required(ErrorMessage ="Door Type is Required")]
        public string Doors { get; set; }

        [Required]
        [Display(Name ="Interior Color")]
        public string InteriorColor { get; set; }

        [Required]
        [Display(Name = "Exterior Color")]
        public string ExteriorColor { get; set; }

        public Int32 Year { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name="Other Details about car")]
        public string OtherDetails { get; set; }
        public string FolderName { get; set; }
        public string DisplayFileName { get; set; }
        //public string DisplayFileType { get; set; }
        public string ArrayFileName { get; set; }
     
        public string ThumbFolderName { get; set; }

        [Display(Name="Date Upload")]
        public DateTime UploadedDate { get; set; }

        [Required(ErrorMessage = "Brand is Required")]
        [Display(Name = "Brand")]
        public int BrandsId { get; set; }
        public Brands Brands { get; set; }

        [Required(ErrorMessage ="Model is Required")]
        [Display(Name = "Model")]
        public int CarsModelId { get; set; }

        public string ModelName { get; set; }

        [Required(ErrorMessage = "Transmission is Required")]
        [Display(Name ="Transmission")]
        public int TransmissionId { get; set; }
        public Transmission Transmissions { get; set; }

        [Required(ErrorMessage = "Car Status is Required")]
        [Display(Name = "Car Status")]
        public int CarStatusId { get; set; }
        public CarStatus CarStatus { get; set; }






    }
}
