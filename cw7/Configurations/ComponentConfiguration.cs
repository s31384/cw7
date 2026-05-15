using cw7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw7.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(u => u.Code);
                
        builder.Property(u => u.Code).HasColumnType("char(10)");
        builder.Property(u => u.Name).HasMaxLength(300);
        builder.Property(u => u.Description).HasColumnType("nvarchar(max)");
        builder.HasOne(u => u.ComponentManufacturer)
            .WithMany(p => p.Components)
            .HasForeignKey(p => p.ComponentManufacturersId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.ComponentType)
            .WithMany(u => u.Components)
            .HasForeignKey(u => u.ComponentTypesId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("Components");
        
        
        
        builder.HasData(new List<Component>()
        {
            new Component(){Code = "G1050", ComponentManufacturersId = 1, ComponentTypesId = 2, Description = "Good gpu gtx 1050", Name = "GTX1050"},
            new Component(){Code = "I7", ComponentManufacturersId = 2, ComponentTypesId = 1, Description = "old good cpu core i7", Name = "CoreI7"},
            new Component(){Code = "R01", ComponentManufacturersId = 3, ComponentTypesId = 3, Description = "very rare ram", Name = "RAM16GB"},
        });
    }
}