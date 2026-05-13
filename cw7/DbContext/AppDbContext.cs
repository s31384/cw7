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
            new Component(){Code = "G1050", ComponentManufacturersId = 1, ComponentTypesId = 2, Description = "Good gpu gtx 1050", Name = "GTX1050"},
            new Component(){Code = "I7", ComponentManufacturersId = 2, ComponentTypesId = 1, Description = "old good cpu core i7", Name = "CoreI7"},
            new Component(){Code = "R01", ComponentManufacturersId = 3, ComponentTypesId = 3, Description = "very rare ram", Name = "RAM16GB"},
        });

        modelBuilder.Entity<Pc>().HasData(new List<Pc>()
        {
            new Pc(){Id = 1, CreatedAt = new DateTime(2025,12,2), Name = "Gaming monster", Weight = 5.0f, Stock = 2, Warranty = 24},
            new Pc(){Id =2, CreatedAt = new DateTime(2024,5,5), Name = "Office clerk", Stock = 1, Warranty = 48, Weight = 1.5f},
            new Pc(){Id = 3, CreatedAt = new DateTime(2020,6,7), Name = "Home office", Stock = 10, Weight = 3f, Warranty = 24},
        });

        modelBuilder.Entity<PCComponent>().HasData(new List<PCComponent>()
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
        
        base.OnModelCreating(modelBuilder);

    }
    
}