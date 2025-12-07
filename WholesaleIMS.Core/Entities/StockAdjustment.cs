using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleIMS.Core.Entities
{
    public class StockAdjustment
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        // Positive for increase, negative for decrease
        public int QuantityChange { get; set; }

        public StockAdjustmentReason Reason { get; set; }

        public DateTime AdjustmentDate { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; }

        public string? Note { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

