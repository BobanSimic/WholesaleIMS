using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleIMS.Core.Enums
{
    public enum StockAdjustmentReason
    {
        InventoryCount = 1,   // Physical stock check
        Damaged = 2,
        Lost = 3,
        Found = 4
    }
}
