using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Models
{
    public class PaymentDetails
    {
        [Key]
        public int ID { get; set; }
      
        [Required]
        //[Column(TypeName ="nvachar(100)")]
        public string BankName  { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        //[Required]
        //public string Currency { get; set; }
        [Required]
        public string AccountExpiryDate { get; set; }
        [Required]
        public string AccountSecurityNumber { get; set; }
      


    }
}
