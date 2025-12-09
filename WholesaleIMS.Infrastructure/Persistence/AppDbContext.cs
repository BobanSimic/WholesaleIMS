using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WholesaleIMS.Core.Entities;

namespace WholesaleIMS.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        // === DbSets – one per entity ===

        // Catalog
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Parties
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        // Inventory
        public DbSet<StockLevel> StockLevels { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }

        // Purchasing
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }

        // Sales
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderLine> SalesOrderLines { get; set; }

        // Adjustments
        public DbSet<StockAdjustment> StockAdjustments { get; set; }

        // === Model configuration ===
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // This will automatically pick up all IEntityTypeConfiguration<T>
            // from this assembly (we’ll add them next).
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
