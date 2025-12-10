using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesaleIMS.Core.Entities;
using WholesaleIMS.Core.Enums;

namespace WholesaleIMS.Infrastructure.Persistence.Configurations
{
    public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            // --- Table ---
            builder.ToTable("SalesOrders");

            // --- Key ---
            builder.HasKey(so => so.Id);

            // --- Properties ---

            builder.Property(so => so.SoNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            // Sales order number should be unique in the system
            builder.HasIndex(so => so.SoNumber)
                   .IsUnique();

            builder.Property(so => so.BuyerId)
                   .IsRequired();

            builder.Property(so => so.OrderDate)
                   .IsRequired();

            // Status enum -> string (easier to read in DB)
            builder.Property(so => so.Status)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.Property(so => so.CreatedAt)
                   .IsRequired();

            builder.Property(so => so.UpdatedAt)
                   .IsRequired(false);

            // --- Relationships ---

            // Buyer (1) -> (N) SalesOrders
            // Using generic HasOne so it works even if you don't
            // have a Buyer navigation on SalesOrder.
            builder.HasOne<Buyer>()
                   .WithMany()
                   .HasForeignKey(so => so.BuyerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // SalesOrderLine relationship will be configured
            // on the SalesOrderLineConfiguration side.

            // --- Indexes for common queries ---
            builder.HasIndex(so => so.BuyerId);
            builder.HasIndex(so => so.OrderDate);
            builder.HasIndex(so => so.Status);

            // --- Seed Data ---

            var created = new DateTime(2025, 1, 10);

            builder.HasData(
                new SalesOrder
                {
                    Id = 1,
                    SoNumber = "SO-2025-0001",
                    BuyerId = 1, // GameZone Retail d.o.o.
                    OrderDate = new DateTime(2025, 1, 10),
                    Status = SalesOrderStatus.Draft,
                    CreatedAt = created,
                    UpdatedAt = created
                },
                new SalesOrder
                {
                    Id = 2,
                    SoNumber = "SO-2025-0002",
                    BuyerId = 2, // OfficePro Computers d.o.o.
                    OrderDate = new DateTime(2025, 1, 11),
                    Status = SalesOrderStatus.Confirmed,
                    CreatedAt = created,
                    UpdatedAt = created
                },
                new SalesOrder
                {
                    Id = 3,
                    SoNumber = "SO-2025-0003",
                    BuyerId = 3, // Global IT Solutions d.o.o.
                    OrderDate = new DateTime(2025, 1, 12),
                    Status = SalesOrderStatus.Pending, // or Completed, adjust to your enum
                    CreatedAt = created,
                    UpdatedAt = created
                }
            );
        }
    }
}
