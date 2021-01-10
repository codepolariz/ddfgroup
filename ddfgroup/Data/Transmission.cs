using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ddfgroup.Data
{
    public class Transmission
    {


        [Key]
        public int TransmissionId { get; set; }

        [Display(Name ="Transmission")]
        public string Name { get; set; }

        public IList<Cars> Cars { get; set; }

    }
}
