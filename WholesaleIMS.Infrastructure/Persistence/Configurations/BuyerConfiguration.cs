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
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            // --- Table ---
            builder.ToTable("Buyers");

            // --- Key ---
            builder.HasKey(b => b.Id);

            // --- Properties ---
            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(b => b.TaxNumber)
                   .HasMaxLength(50);

            builder.Property(b => b.ContactPerson)
                   .HasMaxLength(200);

            builder.Property(b => b.Email)
                   .HasMaxLength(200);

            builder.Property(b => b.Phone)
                   .HasMaxLength(50);

            builder.Property(b => b.AddressLine)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(b => b.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.PostalCode)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(b => b.Country)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.IsActive)
                   .IsRequired();

            builder.Property(b => b.CreatedAt)
                   .IsRequired();

            builder.Property(b => b.UpdatedAt)
                   .IsRequired(false);

            // SalesOrder relationship (Buyer 1..N SalesOrders) will be configured
            // later on the SalesOrder side.

            // --- Seed Data ---
            var seedDate = new DateTime(2025, 1, 1);

            builder.HasData(
                new Buyer
                {
                    Id = 1,
                    Name = "GameZone Retail d.o.o.",
                    TaxNumber = "SI87654321",
                    ContactPerson = "Tomaž Kovač",
                    Email = "narocila@gamezone-retail.si",
                    Phone = "+386 1 555 2000",
                    AddressLine = "Trgovska ulica 5",
                    City = "Ljubljana",
                    PostalCode = "1000",
                    Country = "Slovenia",
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                },
                new Buyer
                {
                    Id = 2,
                    Name = "OfficePro Computers d.o.o.",
                    TaxNumber = "SI55667788",
                    ContactPerson = "Petra Horvat",
                    Email = "info@officepro-computers.si",
                    Phone = "+386 2 600 3000",
                    AddressLine = "Poslovna cesta 12",
                    City = "Maribor",
                    PostalCode = "2000",
                    Country = "Slovenia",
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                },
                new Buyer
                {
                    Id = 3,
                    Name = "Global IT Solutions d.o.o.",
                    TaxNumber = "SI99887766",
                    ContactPerson = "Jure Vidmar",
                    Email = "orders@global-it-solutions.si",
                    Phone = "+386 4 700 1234",
                    AddressLine = "Tehnološki park 8",
                    City = "Kranj",
                    PostalCode = "4000",
                    Country = "Slovenia",
                    IsActive = true,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate
                }
            );
        }
    }
}
