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
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            // --- Table ---
            builder.ToTable("Suppliers");

            // --- Key ---
            builder.HasKey(s => s.Id);

            // --- Properties ---

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(s => s.TaxNumber)
                   .HasMaxLength(50);

            builder.Property(s => s.ContactPerson)
                   .HasMaxLength(200);

            builder.Property(s => s.Email)
                   .HasMaxLength(200);

            builder.Property(s => s.Phone)
                   .HasMaxLength(50);

            builder.Property(s => s.AddressLine)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(s => s.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.PostalCode)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.Country)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.IsActive)
                   .IsRequired();

            builder.Property(s => s.CreatedAt)
                   .IsRequired();

            builder.Property(s => s.UpdatedAt)
                   .IsRequired(false);

            // Relationships to PurchaseOrder will be configured on the PurchaseOrder side later
            // (Supplier 1..N PurchaseOrders).

            // --- Seed Data ---
            var seedDate = new DateTime(2025, 1, 1);

            builder.HasData(
                new Supplier
                {
                    Id = 1,
                    Name = "TechCore Distribution Ltd",
                    TaxNumber = "SI12345678",
                    ContactPerson = "Marko Novak",
                    Email = "sales@techcore-distribution.com",
                    Phone = "+386 1 555 1000",
                    AddressLine = "Industrialna cesta 10",
                    City = "Ljubljana",
                    PostalCode = "1000",
                    Country = "Slovenia",
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                },
                new Supplier
                {
                    Id = 2,
                    Name = "Nordic Components GmbH",
                    TaxNumber = "DE987654321",
                    ContactPerson = "Anna Müller",
                    Email = "orders@nordic-components.de",
                    Phone = "+49 89 1234 567",
                    AddressLine = "Hauptstrasse 45",
                    City = "Munich",
                    PostalCode = "80331",
                    Country = "Germany",
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                },
                new Supplier
                {
                    Id = 3,
                    Name = "PixelWave Electronics SpA",
                    TaxNumber = "IT11223344",
                    ContactPerson = "Luca Rossi",
                    Email = "info@pixelwave.it",
                    Phone = "+39 02 7654 321",
                    AddressLine = "Via Tecnologica 21",
                    City = "Milan",
                    PostalCode = "20100",
                    Country = "Italy",
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                }
            );
        }
    }
}
