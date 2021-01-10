using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ddfgroup.Data
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Full name")]
        public  string Name { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name="Mobile Number")]
        //[MaxLength(11, ErrorMessage ="Mobile Number is Invalid. maximun lenght")]
        //[MinLength(7, ErrorMessage = "Mobile Number is incorrect. Minimum Length")]
        public  string MobileNumber { get; set; }

        [Required]
        [Display(Name= "Details of Desired Car")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        
    }
}
