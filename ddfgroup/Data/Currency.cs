using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ddfgroup.Data
{
    public class Currency 
    {
        [Key]
        public Int64 CurrencyId { get; set; }

        [Required(ErrorMessage = "Base Currency is Required")]

        [Display(Name="Base Currency")]
        public string BaseCurrency { get; set; }

        [Display(Name = "Base Amount")]
        [Required(ErrorMessage="Base Currency Amount is required")]
        public int BaseAmount { get; set; }

        [Display(Name = "Exchange Currency")]
        [Required(ErrorMessage = "Exchnage Currency is required")]
        public string ExchangeCurrency { get; set; }

        [Display(Name = "Exchange Amount")]
        [Required(ErrorMessage = "Exchanged Currency Amount is required")]
        public int ExchnageRateAmount { get; set; }
    }
}
