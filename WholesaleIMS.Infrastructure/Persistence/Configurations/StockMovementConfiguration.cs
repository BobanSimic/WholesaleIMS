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
    public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            // --- Table ---
            builder.ToTable("StockMovements");

            // --- Key ---
            builder.HasKey(sm => sm.Id);

            // --- Properties ---

            builder.Property(sm => sm.ItemId)
                   .IsRequired();

            builder.Property(sm => sm.QuantityChange)
                   .IsRequired();
            // If QuantityChange is decimal in your entity, you can later add:
            // .HasColumnType("decimal(18,2)");

            builder.Property(sm => sm.MovementDate)
                   .IsRequired();

            builder.Property(sm => sm.Note)
                   .HasMaxLength(1000);

            // MovementType: store enum as string for readability in DB
            builder.Property(sm => sm.MovementType)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(50);

            // --- Relationships ---

            // Item (1) -> (N) StockMovement
            builder.HasOne(sm => sm.Item)
                   .WithMany() // Item doesn't need a StockMovements collection
                   .HasForeignKey(sm => sm.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // PurchaseOrderLine (1) -> (0..N) StockMovement (goods received)
            // nullable FK
            builder.HasOne<PurchaseOrderLineConfiguration>()
                   .WithMany()
                   .HasForeignKey(sm => sm.PurchaseOrderLineId)
                   .OnDelete(DeleteBehavior.Restrict);

            // SalesOrderLine (1) -> (0..N) StockMovement (goods shipped)
            // nullable FK
            builder.HasOne<SalesOrderLineConfiguration>()
                   .WithMany()
                   .HasForeignKey(sm => sm.SalesOrderLineId)
                   .OnDelete(DeleteBehavior.Restrict);

            // StockAdjustment (1) -> (0..1) StockMovement (when confirmed)
            // nullable FK
            builder.HasOne<StockAdjustment>()
                   .WithMany()
                   .HasForeignKey(sm => sm.StockAdjustmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // --- Indexes ---
            // For common queries: by Item, by date, by type
            builder.HasIndex(sm => sm.ItemId);
            builder.HasIndex(sm => sm.MovementDate);
            builder.HasIndex(sm => sm.MovementType);
        }
    }

}
