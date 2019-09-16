using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Models
{
    public enum PaymentStatus
    {
        Unpaid = 1,
        PartPaid = 2,       
        PartRefunded = 4,
        Refunded = 5,
        Completed = 6
    }
}
