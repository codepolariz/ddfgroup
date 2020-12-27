using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ddfgroup.Data
{
    public class PageContents
    {


        [Key]
        public int Id { get; set; }

        [Display(Name = "Page Title")]
        [Required]
        [MaxLength(10)]
        public String PageTitle { get; set; }

        [Display(Name = "Page Content")]
        [Required]
        public String PageContent { get; set; }
    }
}
