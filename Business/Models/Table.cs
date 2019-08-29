﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Models
{
    public abstract class Table
    {
        [Column(Order = 0)]
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        [Required]
        public bool IsDeleted { get; set; }
    }
}
