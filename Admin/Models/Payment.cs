using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string IBAN { get; set; }
        [Required]

        public string RIB { get; set; }
        [Required]
        //[Column(TypeName ="nvachar(100)")]
        public string BankName { get; set; }
    }
}