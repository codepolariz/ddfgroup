using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ddfgroup.Data
{
    public class CarStatus
    {
        [Key]
        public int CarStatusId { get; set; }

        [Required]
        [Display(Name ="Status")]
        public string StatusName { get; set; }

        public IList<Cars> Cars { get; set; }
    }
}
