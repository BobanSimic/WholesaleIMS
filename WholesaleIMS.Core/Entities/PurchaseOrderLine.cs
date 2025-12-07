using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleIMS.Core.Entities
{
    public class PurchaseOrderLine
    {
        public int Id { get; set; }

        public int PurchaseOrderId { get; set; }

        public int ItemId { get; set; }

        public int QuantityOrdered { get; set; }

        // How much was actually received so far (supports partial deliveries)
        public int QuantityReceived { get; set; }

        public string? Note { get; set; }
    }
}
