
using Foxic.Core.Entities.Areas;
using Foxic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Foxic.DataAccess.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>	
{
    public readonly object Collection;

    public AppDbContext(DbContextOptions <AppDbContext> options) : base(options) 
    { 
    }
	public DbSet<Slider> Sliders { get; set; } = null!;
	public DbSet<Brand> Brands { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Collections> Collections { get; set; }
	public DbSet<Color> Colors { get; set; } = null!;
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderItem> OrderItems { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<ProductColor> ProductColors { get; set; }
	public DbSet<ProductDetail> ProductDetails { get; set; }
	public DbSet<ProductSize> ProductSizes { get; set; }
	public DbSet<Size> Sizes { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Brand>()
            .HasIndex(p => p.BrandName)
            .IsUnique();
        modelBuilder.Entity<Collections>()
            .HasIndex(p => p.CollectionName)
            .IsUnique();
        modelBuilder.Entity<Category>()
            .HasIndex(p => p.CategoryName)
            .IsUnique();
        modelBuilder.Entity<Color>()
            .HasIndex(p => p.Name)
            .IsUnique();
        modelBuilder.Entity<Size>()
            .HasIndex(p => p.Name)
            .IsUnique();

    }
}
