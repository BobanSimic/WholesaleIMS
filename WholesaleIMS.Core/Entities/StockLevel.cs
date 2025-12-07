using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleIMS.Core.Entities
{
    public class StockLevel
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        // quantity treated as whole units, switch to decimal if needed(kg, l)
        public int CurrentQuantity { get; set; }

        public int MinimumQuantity { get; set; }

    }
}
