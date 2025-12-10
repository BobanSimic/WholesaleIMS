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
    public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            // --- Table ---
            builder.ToTable("PurchaseOrders");

            // --- Key ---
            builder.HasKey(po => po.Id);

            // --- Properties ---

            builder.Property(po => po.PoNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            // PO number should be unique in the system
            builder.HasIndex(po => po.PoNumber)
                   .IsUnique();

            builder.Property(po => po.SupplierId)
                   .IsRequired();

            builder.Property(po => po.OrderDate)
                   .IsRequired();

            builder.Property(po => po.ExpectedDate)
                   .IsRequired(false);

            // Status enum -> string: Draft, Received, Confirmed, Cancelled
            builder.Property(po => po.Status)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.Property(po => po.CreatedAt)
                   .IsRequired();

            builder.Property(po => po.UpdatedAt)
                   .IsRequired(false);

            // --- Relationships ---

            // Supplier (1) -> (N) PurchaseOrder
            // We don't rely on navigation properties here,
            // so this works even if PurchaseOrder doesn't expose Supplier.
            builder.HasOne<Supplier>()
                   .WithMany()
                   .HasForeignKey(po => po.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            // We'll configure PurchaseOrderLine on its own config class later.

            // --- Indexes for queries ---
            builder.HasIndex(po => po.SupplierId);
            builder.HasIndex(po => po.OrderDate);
            builder.HasIndex(po => po.Status);

            // --- Seed Data ---
            var created = new DateTime(2025, 1, 5);

            builder.HasData(
                new PurchaseOrder
                {
                    Id = 1,
                    PoNumber = "PO-2025-0001",
                    SupplierId = 1, // TechCore Distribution Ltd
                    OrderDate = new DateTime(2025, 1, 5),
                    ExpectedDate = new DateTime(2025, 1, 12),
                    Status = PurchaseOrderStatus.Draft,
                    CreatedAt = created,
                    UpdatedAt = created
                },
                new PurchaseOrder
                {
                    Id = 2,
                    PoNumber = "PO-2025-0002",
                    SupplierId = 2, // Nordic Components GmbH
                    OrderDate = new DateTime(2025, 1, 6),
                    ExpectedDate = new DateTime(2025, 1, 14),
                    Status = PurchaseOrderStatus.Confirmed,
                    CreatedAt = created,
                    UpdatedAt = created
                },
                new PurchaseOrder
                {
                    Id = 3,
                    PoNumber = "PO-2025-0003",
                    SupplierId = 3, // PixelWave Electronics SpA
                    OrderDate = new DateTime(2025, 1, 8),
                    ExpectedDate = null,
                    Status = PurchaseOrderStatus.Pending,
                    CreatedAt = created,
                    UpdatedAt = created
                }
            );
        }
    }
}
