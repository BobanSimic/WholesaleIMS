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
    public class StockLevelConfiguration : IEntityTypeConfiguration<StockLevel>
    {
        public void Configure(EntityTypeBuilder<StockLevel> builder)
        {
            // --- Table ---
            builder.ToTable("StockLevels");

            // --- Key ---
            builder.HasKey(sl => sl.Id);

            // --- Properties ---
            builder.Property(sl => sl.ItemId)
                   .IsRequired();

            builder.Property(sl => sl.CurrentQuantity)
                   .IsRequired();

            builder.Property(sl => sl.MinimumQuantity)
                   .IsRequired();

            // --- Relationship ---
            // Item (1) -> (0 or 1) StockLevel
            // We enforce "0 or 1" at DB level with a UNIQUE index on ItemId.
            builder.HasOne<Item>()              // no need for a navigation property on StockLevel
                   .WithMany()                  // Item does not expose a collection of StockLevels
                   .HasForeignKey(sl => sl.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Ensure at most one StockLevel per Item
            builder.HasIndex(sl => sl.ItemId)
                   .IsUnique();

            // --- Seed Data ---
            // Using your seeded Items:
            // 1–3: PC Components, 4–5: Monitors, 6–7: Peripherals

            builder.HasData(
                new StockLevel
                {
                    Id = 1,
                    ItemId = 1,          // Intel i7-14700K
                    CurrentQuantity = 25,
                    MinimumQuantity = 5
                },
                new StockLevel
                {
                    Id = 2,
                    ItemId = 2,          // RTX 5070 Ti
                    CurrentQuantity = 10,
                    MinimumQuantity = 3
                },
                new StockLevel
                {
                    Id = 3,
                    ItemId = 3,          // Samsung 990 PRO 2TB
                    CurrentQuantity = 40,
                    MinimumQuantity = 10
                },
                new StockLevel
                {
                    Id = 4,
                    ItemId = 4,          // Dell 27" QHD
                    CurrentQuantity = 8,
                    MinimumQuantity = 2
                },
                new StockLevel
                {
                    Id = 5,
                    ItemId = 5,          // LG 34" UW
                    CurrentQuantity = 5,
                    MinimumQuantity = 2
                },
                new StockLevel
                {
                    Id = 6,
                    ItemId = 6,          // Keychron K8 Pro
                    CurrentQuantity = 30,
                    MinimumQuantity = 5
                },
                new StockLevel
                {
                    Id = 7,
                    ItemId = 7,          // Logitech G Pro X
                    CurrentQuantity = 12,
                    MinimumQuantity = 4
                }
            );
        }
    }
}
