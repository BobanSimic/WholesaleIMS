using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WholesaleIMS.Core.Entities;

namespace WholesaleIMS.Infrastructure.Persistence.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            // --- Table ---
            builder.ToTable("Items");

            // --- Key ---
            builder.HasKey(i => i.Id);

            // --- Properties ---
            builder.Property(i => i.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            // Unique index on Code
            builder.HasIndex(i => i.Code)
                   .IsUnique();

            builder.Property(i => i.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(i => i.Description)
                   .HasMaxLength(1000);

            builder.Property(i => i.IsActive)
                   .IsRequired();

            builder.Property(i => i.CreatedAt)
                   .IsRequired();

            builder.Property(i => i.UpdatedAt)
                   .IsRequired(false);

            builder.Property(i => i.CategoryId)
                   .IsRequired();

            // --- Relationships ---
            builder.HasOne(i => i.Category)
                   .WithMany() // Category has no Items collection
                   .HasForeignKey(i => i.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            // --- Seed Data ---
            // CategoryId 1 = PC Components
            // CategoryId 2 = Monitors & Displays
            // CategoryId 3 = Peripherals & Accessories

            var seedDate = new DateTime(2025, 1, 1);

            builder.HasData(
                new Item
                {
                    Id = 1,
                    Code = "100001",
                    Name = "Intel Core i7-14700K",
                    Description = "14th Gen Intel Core i7 processor for high-performance desktops.",
                    CategoryId = 1, // PC Components
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                },
                new Item
                {
                    Id = 2,
                    Code = "100002",
                    Name = "NVIDIA GeForce RTX 5070 Ti",
                    Description = "High-end gaming and productivity graphics card.",
                    CategoryId = 1,
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                },
                new Item
                {
                    Id = 3,
                    Code = "100003",
                    Name = "Samsung 990 PRO 2TB NVMe SSD",
                    Description = "PCIe 4.0 NVMe SSD offering fast and reliable storage.",
                    CategoryId = 1,
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                },
                new Item
                {
                    Id = 4,
                    Code = "200001",
                    Name = "Dell UltraSharp 27\" QHD 165Hz Monitor",
                    Description = "27-inch QHD IPS monitor with a high refresh rate.",
                    CategoryId = 2, // Monitors & Displays
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                },
                new Item
                {
                    Id = 5,
                    Code = "200002",
                    Name = "LG UltraGear 34\" Ultrawide 144Hz Monitor",
                    Description = "34-inch ultrawide gaming monitor with 144Hz refresh rate.",
                    CategoryId = 2,
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                },
                new Item
                {
                    Id = 6,
                    Code = "300001",
                    Name = "Keychron K8 Pro Mechanical Keyboard",
                    Description = "Tenkeyless mechanical keyboard ideal for productivity and gaming.",
                    CategoryId = 3, // Peripherals & Accessories
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                },
                new Item
                {
                    Id = 7,
                    Code = "300002",
                    Name = "Logitech G Pro X Superlight Mouse",
                    Description = "Ultra-lightweight wireless gaming mouse designed for esports.",
                    CategoryId = 3,
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                }
            );
        }
    }
}
