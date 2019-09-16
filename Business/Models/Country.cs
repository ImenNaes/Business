using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Country
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]

        public string NameAr { get; set; }
    
        public virtual City Cities { get; set; }
    }
}
