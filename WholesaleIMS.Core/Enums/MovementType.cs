using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleIMS.Core.Enums
{
    public enum MovementType
    {
        PurchaseReceive = 1,   // Stock increases when PO is received
        SalesIssue = 2,        // Stock decreases when SO is confirmed
        AdjustmentIncrease = 3,
        AdjustmentDecrease = 4
    }
}
