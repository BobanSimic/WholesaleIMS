using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleIMS.Core.Enums
{
    public enum PurchaseOrderStatus
    {
        Draft = 1,
        Received = 2,      // Quantities recorded, waiting confirmation
        Confirmed = 3,     // Stock officially updated
        Cancelled = 4
    }
}
