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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);

    }
    
}