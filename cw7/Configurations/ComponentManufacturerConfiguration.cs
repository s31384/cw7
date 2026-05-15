using cw7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw7.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Abbreviation).HasMaxLength(30); 
        builder.Property(e => e.FullName).HasMaxLength(300);
        builder.Property(e=> e.FoundationDate).HasColumnType("date");
        builder.ToTable("ComponentManufacturers");
        
        builder.HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer()
                { Abbreviation = "NV", FoundationDate = new DateTime(2019, 12, 31), Id = 1, FullName = "Nvidia" },
            new ComponentManufacturer()
                { Abbreviation = "IN", FoundationDate = new DateTime(2015, 5, 12), Id = 2, FullName = "Intel" },
            new ComponentManufacturer()
                { Abbreviation = "SM", FoundationDate = new DateTime(2006, 1, 16), Id = 3, FullName = "Samsung" },
        });
    }
}