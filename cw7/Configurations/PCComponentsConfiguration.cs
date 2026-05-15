using cw7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw7.Configurations;

public class PcComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> builder)
    {
        builder.HasKey(p => new { p.PCId, p.ComponentCode });
        builder.HasOne(p => p.Pc)
                .WithMany(p => p.PcComponents)
                .HasForeignKey(p => p.PCId)
                .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(p => p.Component)
                .WithMany(p => p.PcComponents)
                .HasForeignKey(p => p.ComponentCode)
                .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("PCComponents");
        
        
        builder.HasData(new List<PCComponent>()
        {
            new PCComponent(){PCId = 1, ComponentCode = "G1050", Amount = 2},
            new PCComponent(){PCId = 1, ComponentCode = "I7", Amount = 1},
            new PCComponent(){PCId = 1, ComponentCode = "R01", Amount = 2},
            new PCComponent(){PCId = 2, ComponentCode = "I7", Amount = 1},
            new PCComponent(){PCId = 2, ComponentCode = "R01", Amount = 1},
            new PCComponent(){PCId = 3, ComponentCode = "G1050", Amount = 1},
            new PCComponent(){PCId = 3, ComponentCode = "I7", Amount = 1},
            new PCComponent(){PCId = 3, ComponentCode = "R01", Amount = 1},
            

        });
    }
}