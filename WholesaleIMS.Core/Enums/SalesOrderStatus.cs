using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleIMS.Core.Enums
{
    public enum SalesOrderStatus
    {
        Draft = 1,
        Confirmed = 2, // stock deducted
        Cancelled = 3
    }
}
