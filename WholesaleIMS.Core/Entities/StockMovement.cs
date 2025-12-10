using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleIMS.Core.Entities
{
    public class StockMovement
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        // Positive for incoming stock (PO receive, adjustment gain),
        // negative for outgoing stock (sales, adjustment loss).
        public int QuantityChange { get; set; }

        //  create this enum later under WholesaleIMS.Core.Enums
        public MovementType MovementType { get; set; }

        // Nullable links to the source of this movement
        public int? PurchaseOrderLineId { get; set; }

        public int? SalesOrderLineId { get; set; }

        public int? StockAdjustmentId { get; set; }

        public DateTime MovementDate { get; set; } = DateTime.UtcNow;

        public string? Note { get; set; }

        public Item Item { get; set; }

    }
}
