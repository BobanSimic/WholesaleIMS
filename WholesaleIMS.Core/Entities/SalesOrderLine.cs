using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleIMS.Core.Entities
{
    public class SalesOrderLine
    {
        public int Id { get; set; }

        public int SalesOrderId { get; set; }

        public int ItemId { get; set; }

        public int QuantityOrdered { get; set; }

        // If you later support partial shipments, this is useful.
        public int QuantityShipped { get; set; }

        public string? Note { get; set; }
    }
}

