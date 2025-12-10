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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // --- Table ---
            // EF Core default would be "Categories", but we set it explicitly for clarity.
            builder.ToTable("Categories");

            // --- Key ---
            builder.HasKey(c => c.Id);

            // --- Properties ---
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Description)
                   .HasMaxLength(1000);

            builder.Property(c => c.IsActive)
                   .IsRequired();

            builder.Property(c => c.CreatedAt)
                   .IsRequired();

            builder.Property(c => c.UpdatedAt)
                   .IsRequired(false);

            // NOTE:
            // No navigation Items collection on Category.
            // Relationship is configured in ItemConfiguration via:
            // builder.HasOne(i => i.Category).WithMany().HasForeignKey(i => i.CategoryId);

            // --- Seed Data ---
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "PC Components",
                    Description = "CPUs, GPUs, RAM, storage, motherboards, power supplies and other internal PC parts.",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1),
                    UpdatedAt = new DateTime(2025, 1, 1)
                },
                new Category
                {
                    Id = 2,
                    Name = "Monitors & Displays",
                    Description = "Monitors of various sizes, resolutions, and display technologies.",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1),
                    UpdatedAt = new DateTime(2025, 1, 1)
                },
                new Category
                {
                    Id = 3,
                    Name = "Peripherals & Accessories",
                    Description = "Keyboards, mice, headphones, mousepads and related PC accessories.",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1),
                    UpdatedAt = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
