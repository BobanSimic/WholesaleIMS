using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesaleIMS.Core.Entities;

namespace WholesaleIMS.Infrastructure.Persistence.Configurations
{
    public class PurchaseOrderLineConfiguration : IEntityTypeConfiguration<PurchaseOrderLine>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderLine> builder)
        {
            // --- Table ---
            builder.ToTable("PurchaseOrderLines");

            // --- Key ---
            builder.HasKey(pol => pol.Id);

            // --- Properties ---
            builder.Property(pol => pol.PurchaseOrderId)
                   .IsRequired();

            builder.Property(pol => pol.ItemId)
                   .IsRequired();

            builder.Property(pol => pol.QuantityOrdered)
                   .IsRequired();
            // If QuantityOrdered is decimal, you can later add:
            // .HasColumnType("decimal(18,2)");

            builder.Property(pol => pol.QuantityReceived)
                   .IsRequired();
            // And the same here if decimal:
            // .HasColumnType("decimal(18,2)");

            builder.Property(pol => pol.Note)
                   .HasMaxLength(1000);

            // --- Relationships ---

            // PurchaseOrder (1) -> (N) PurchaseOrderLine
            // Using generic HasOne<> so this works even if you don't
            // have a navigation property on PurchaseOrderLine yet.
            builder.HasOne<PurchaseOrder>()
                   .WithMany()
                   .HasForeignKey(pol => pol.PurchaseOrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Item (1) -> (N) PurchaseOrderLine
            builder.HasOne<Item>()
                   .WithMany()
                   .HasForeignKey(pol => pol.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // --- Indexes ---
            builder.HasIndex(pol => pol.PurchaseOrderId);
            builder.HasIndex(pol => pol.ItemId);

            // --- Seed Data ---
            // Matches your seeded PurchaseOrders:
            // PO 1: Draft
            // PO 2: Confirmed
            // PO 3: Received
            //
            // Items:
            // 1–3 = PC Components, 4–5 = Monitors, 6–7 = Peripherals

            builder.HasData(
                // PO-2025-0001 (Draft) - not received yet
                new PurchaseOrderLine
                {
                    Id = 1,
                    PurchaseOrderId = 1,   // PO-2025-0001, Supplier 1
                    ItemId = 1,            // Intel i7-14700K
                    QuantityOrdered = 20,
                    QuantityReceived = 0,
                    Note = "Initial CPU stock order."
                },
                new PurchaseOrderLine
                {
                    Id = 2,
                    PurchaseOrderId = 1,
                    ItemId = 2,            // RTX 5070 Ti
                    QuantityOrdered = 10,
                    QuantityReceived = 0,
                    Note = "High-end GPU batch."
                },

                // PO-2025-0002 (Confirmed) - partially received
                new PurchaseOrderLine
                {
                    Id = 3,
                    PurchaseOrderId = 2,   // PO-2025-0002, Supplier 2
                    ItemId = 3,            // Samsung 990 PRO 2TB
                    QuantityOrdered = 30,
                    QuantityReceived = 10,
                    Note = "Partial SSD delivery received."
                },
                new PurchaseOrderLine
                {
                    Id = 4,
                    PurchaseOrderId = 2,
                    ItemId = 4,            // Dell 27\" QHD
                    QuantityOrdered = 10,
                    QuantityReceived = 5,
                    Note = "First half of monitor shipment."
                },

                // PO-2025-0003 (Received) - fully received
                new PurchaseOrderLine
                {
                    Id = 5,
                    PurchaseOrderId = 3,   // PO-2025-0003, Supplier 3
                    ItemId = 5,            // LG 34\" UW
                    QuantityOrdered = 15,
                    QuantityReceived = 15,
                    Note = "Full ultrawide monitor order received."
                },
                new PurchaseOrderLine
                {
                    Id = 6,
                    PurchaseOrderId = 3,
                    ItemId = 6,            // Keychron K8 Pro
                    QuantityOrdered = 20,
                    QuantityReceived = 20,
                    Note = "Mechanical keyboards fully delivered."
                }
            );
        }
    }
}
