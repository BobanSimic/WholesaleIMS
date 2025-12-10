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
    public class StockAdjustmentConfiguration : IEntityTypeConfiguration<StockAdjustment>
    {
        public void Configure(EntityTypeBuilder<StockAdjustment> builder)
        {
            // --- Table ---
            builder.ToTable("StockAdjustments");

            // --- Key ---
            builder.HasKey(sa => sa.Id);

            // --- Properties ---

            builder.Property(sa => sa.ItemId)
                   .IsRequired();

            builder.Property(sa => sa.QuantityChange)
                   .IsRequired();
            // If QuantityChange is decimal, you can uncomment:
            // .HasColumnType("decimal(18,2)");

            builder.Property(sa => sa.AdjustmentDate)
                   .IsRequired();

            // Reason enum -> string
            builder.Property(sa => sa.Reason)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(50);

            // Status enum -> string: "Draft" / "Confirmed"
            builder.Property(sa => sa.Status)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.Property(sa => sa.CreatedAt)
                   .IsRequired();

            builder.Property(sa => sa.UpdatedAt)
                   .IsRequired(false);

            // --- Relationships ---

            builder.HasOne(sa => sa.Item)
                   .WithMany()
                   .HasForeignKey(sa => sa.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // --- Indexes ---
            builder.HasIndex(sa => sa.ItemId);
            builder.HasIndex(sa => sa.AdjustmentDate);
            builder.HasIndex(sa => sa.Status);
        }
    }
}
