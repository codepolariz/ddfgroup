using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ddfgroup.Data
{
    public class CarImages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cid { get; set; } 

        public string ImagesName { get; set; }
        public string FolderName { get; set; }

       
        public int  CarsId { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}
