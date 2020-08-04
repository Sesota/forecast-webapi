using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace ForecastApi
{
  public class DatabaseContext : DbContext
  {
    public DbSet<Region> Regions { get; set; }
    public DbSet<Weather> Weathers { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Region>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Latitude).IsRequired();
        entity.Property(e => e.Longitude).IsRequired();
      });
      modelBuilder.Entity<Weather>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Date).IsRequired();
        entity.Property(e => e.Condition).IsRequired();
        entity.HasOne(m => m.Region).WithMany(d => d.Weathers);
      });
    }
  }
}