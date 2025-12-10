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
    public class SalesOrderLineConfiguration : IEntityTypeConfiguration<SalesOrderLine>
    {
        public void Configure(EntityTypeBuilder<SalesOrderLine> builder)
        {
            // --- Table ---
            builder.ToTable("SalesOrderLines");

            // --- Key ---
            builder.HasKey(sol => sol.Id);

            // --- Properties ---

            builder.Property(sol => sol.SalesOrderId)
                   .IsRequired();

            builder.Property(sol => sol.ItemId)
                   .IsRequired();

            builder.Property(sol => sol.QuantityOrdered)
                   .IsRequired();
            // If decimal, you can later specify:
            // .HasColumnType("decimal(18,2)");

            builder.Property(sol => sol.QuantityShipped)
                   .IsRequired();
            // If you made QuantityShipped nullable in the entity,
            // change to .IsRequired(false);

            builder.Property(sol => sol.Note)
                   .HasMaxLength(1000);

            // --- Relationships ---

            // SalesOrder (1) -> (N) SalesOrderLine
            builder.HasOne<SalesOrder>()
                   .WithMany()
                   .HasForeignKey(sol => sol.SalesOrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Item (1) -> (N) SalesOrderLine
            builder.HasOne<Item>()
                   .WithMany()
                   .HasForeignKey(sol => sol.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // --- Indexes ---
            builder.HasIndex(sol => sol.SalesOrderId);
            builder.HasIndex(sol => sol.ItemId);

            // --- Seed Data ---
            // Match seeded SalesOrders:
            // SO-2025-0001 (Id = 1, Buyer 1, Draft)
            // SO-2025-0002 (Id = 2, Buyer 2, Confirmed)
            // SO-2025-0003 (Id = 3, Buyer 3, Pending)
            //
            // Items:
            // 1–3: PC Components, 4–5: Monitors, 6–7: Peripherals

            builder.HasData(
                // SO-2025-0001 (Draft) - nothing shipped yet
                new SalesOrderLine
                {
                    Id = 1,
                    SalesOrderId = 1,   // SO-2025-0001
                    ItemId = 1,         // Intel i7-14700K
                    QuantityOrdered = 3,
                    QuantityShipped = 0,
                    Note = "Pre-order CPUs for GameZone."
                },
                new SalesOrderLine
                {
                    Id = 2,
                    SalesOrderId = 1,
                    ItemId = 6,         // Keychron K8 Pro
                    QuantityOrdered = 5,
                    QuantityShipped = 0,
                    Note = "Keyboards for new gaming area."
                },

                // SO-2025-0002 (Confirmed) - partially shipped
                new SalesOrderLine
                {
                    Id = 3,
                    SalesOrderId = 2,   // SO-2025-0002
                    ItemId = 4,         // Dell 27\" QHD
                    QuantityOrdered = 4,
                    QuantityShipped = 2,
                    Note = "Two monitors shipped, two pending."
                },
                new SalesOrderLine
                {
                    Id = 4,
                    SalesOrderId = 2,
                    ItemId = 3,         // Samsung 990 PRO 2TB
                    QuantityOrdered = 6,
                    QuantityShipped = 3,
                    Note = "Partial SSD shipment."
                },

                // SO-2025-0003 (Shipped) - fully shipped
                new SalesOrderLine
                {
                    Id = 5,
                    SalesOrderId = 3,   // SO-2025-0003
                    ItemId = 2,         // RTX 5070 Ti
                    QuantityOrdered = 2,
                    QuantityShipped = 2,
                    Note = "High-end GPU order completed."
                },
                new SalesOrderLine
                {
                    Id = 6,
                    SalesOrderId = 3,
                    ItemId = 7,         // Logitech G Pro X mouse
                    QuantityOrdered = 5,
                    QuantityShipped = 5,
                    Note = "Gaming mice fully shipped."
                }
            );
        }
    }
}
