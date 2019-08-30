using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int SuggestedCount { get; set; }
        public string Value1 { get; set; }
        public string Label { get; set; }
        public string LabelEn { get; set; }
        public decimal? FromPrice { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid? CitiesID { get; set; }
        public DateTime? EndDate { get; set; }
        public bool PreOrder { get; set; }
        public string Code { get; set; }
        public Guid? ProductSmallImagesID { get; set; }
        public DateTime? StartDate { get; set; }
    }
}