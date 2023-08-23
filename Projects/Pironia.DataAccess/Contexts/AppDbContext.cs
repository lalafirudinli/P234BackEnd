using Microsoft.EntityFrameworkCore;
using Pironia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pironia.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    { }

    public DbSet<Slider> Sliders { get; set; } = null!;

    public DbSet<Service> Services { get; set; } = null!;

}
