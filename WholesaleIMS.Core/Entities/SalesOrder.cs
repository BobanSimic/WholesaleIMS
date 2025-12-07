using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleIMS.Core.Entities
{
    public class SalesOrder
    {
        public int Id { get; set; }

        public string SoNumber { get; set; } = string.Empty;

        public int BuyerId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public SalesOrderStatus Status { get; set; } = SalesOrderStatus.Draft;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
