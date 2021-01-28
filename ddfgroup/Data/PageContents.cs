using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ddfgroup.Data
{
    public class PageContents
    {


        [Key]
        public int Id { get; set; }

        [Display(Name = "Page Title")]
        [Required]
        public String PageTitle { get; set; }

        [Display(Name = "Page Content")]
        [Required]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public String PageContent { get; set; }
    }
}
