using cw7.Entities;

namespace cw7.DbContext;
using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    protected AppDbContext()
    {
        
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Component> Components {get;set;}
    public DbSet<ComponentType> ComponentTypes {get;set;}
    public DbSet<PCComponent> PCComponents {get;set;}
    public DbSet<Pc> Pcs {get;set;}
    public DbSet<ComponentManufacturer> ComponentManufacturers {get;set;}



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pc>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Weight).HasColumnType("float(5)");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            
            entity.ToTable("PCs");
            
        });

        modelBuilder.Entity<PCComponent>(entity =>
        {
            entity.HasKey(p => new { p.PCId, p.ComponentCode });
            entity.HasOne(p => p.Pc)
                .WithMany(p => p.PcComponents)
                .HasForeignKey(p => p.PCId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(p => p.Component)
                .WithMany(p => p.PcComponents)
                .HasForeignKey(p => p.ComponentCode)
                .OnDelete(DeleteBehavior.Cascade);
            entity.ToTable("PCComponents");
        });

        modelBuilder.Entity<Component>(entity =>
            {
                entity.HasKey(u => u.Code);
                
                entity.Property(u => u.Code).HasColumnType("char(10)");
                entity.Property(u => u.Name).HasMaxLength(300);
                entity.Property(u => u.Description).HasColumnType("nvarchar(max)");
                entity.HasOne(u => u.ComponentManufacturer)
                    .WithMany(p => p.Components)
                    .HasForeignKey(p => p.ComponentManufacturersId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.ComponentType)
                    .WithMany(u => u.Components)
                    .HasForeignKey(u => u.ComponentTypesId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.ToTable("Components");
            }
            );
        modelBuilder.Entity<ComponentType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.Abbreviation).HasMaxLength(30);
                entity.ToTable("ComponentTypes");
            }

        );

        modelBuilder.Entity<ComponentManufacturer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Abbreviation).HasMaxLength(30); 
            entity.Property(e => e.FullName).HasMaxLength(300);
            entity.Property(e=> e.FoundationDate).HasColumnType("date");
            entity.ToTable("ComponentManufacturers");
            
        });

        modelBuilder.Entity<ComponentType>().HasData(new List<ComponentType>()
        {
            new ComponentType() { Abbreviation = "CPU", Name = "Central processing unit", Id = 1 },
            new ComponentType() { Abbreviation = "GPU", Name = "Graphic unit", Id = 2 },
            new ComponentType() { Abbreviation = "RAM", Name = "Random access memory", Id = 3 },
        });

        modelBuilder.Entity<ComponentManufacturer>().HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer()
                { Abbreviation = "NV", FoundationDate = new DateTime(2019, 12, 31), Id = 1, FullName = "Nvidia" },
            new ComponentManufacturer()
                { Abbreviation = "IN", FoundationDate = new DateTime(2015, 5, 12), Id = 2, FullName = "Intel" },
            new ComponentManufacturer()
                { Abbreviation = "SM", FoundationDate = new DateTime(2006, 1, 16), Id = 3, FullName = "Samsung" },
        });

        modelBuilder.Entity<Component>().HasData(new List<Component>()
        {
            new Component(){Code = "B01", ComponentManufacturersId = 1, ComponentTypesId = 2, Description = "Good gpu gtx 1050", Name = "GTX1050"}
        });
        
        base.OnModelCreating(modelBuilder);

    }
    
}