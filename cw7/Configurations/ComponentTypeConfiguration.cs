using cw7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw7.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(150);
        builder.Property(e => e.Abbreviation).HasMaxLength(30);
        builder.ToTable("ComponentTypes");
        
        builder.HasData(new List<ComponentType>()
        {
            new ComponentType() { Abbreviation = "CPU", Name = "Central processing unit", Id = 1 },
            new ComponentType() { Abbreviation = "GPU", Name = "Graphic unit", Id = 2 },
            new ComponentType() { Abbreviation = "RAM", Name = "Random access memory", Id = 3 },
        });
    }
}