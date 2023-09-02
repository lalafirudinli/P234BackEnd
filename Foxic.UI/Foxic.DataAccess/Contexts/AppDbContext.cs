
using Foxic.Core.Entities.Areas;
using Foxic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Foxic.DataAccess.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>	
{
    public AppDbContext(DbContextOptions <AppDbContext> options) : base(options) 
    { 
    }
	public DbSet<Slider> Sliders { get; set; }
	public DbSet<Brand> Brands { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Collections> Collections { get; set; }
	public DbSet<Color> Colors { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderItem> OrderItems { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<ProductColor> ProductColor { get; set; }
	public DbSet<ProductDetail> ProductDetails { get; set; }
	public DbSet<ProductSize> ProductSize { get; set; }
	public DbSet<Size> Size { get; set; }


}
