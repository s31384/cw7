using cw7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw7.Configurations;

public class PcConfiguration : IEntityTypeConfiguration<Pc>
{
    public void Configure(EntityTypeBuilder<Pc> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(50);
        builder.Property(e => e.Weight).HasColumnType("float(5)");
        builder.Property(e => e.CreatedAt).HasColumnType("datetime");
            
        builder.ToTable("PCs");
        
        builder.HasData(new List<Pc>()
        {
            new Pc(){Id = 1, CreatedAt = new DateTime(2025,12,2), Name = "Gaming monster", Weight = 5.0f, Stock = 2, Warranty = 24},
            new Pc(){Id =2, CreatedAt = new DateTime(2024,5,5), Name = "Office clerk", Stock = 1, Warranty = 48, Weight = 1.5f},
            new Pc(){Id = 3, CreatedAt = new DateTime(2020,6,7), Name = "Home office", Stock = 10, Weight = 3f, Warranty = 24},
        });

    }
}