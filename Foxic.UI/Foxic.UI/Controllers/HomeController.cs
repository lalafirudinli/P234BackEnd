using Foxic.DataAccess.Contexts;
using Foxic.UI.ViewModels.HomeVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foxic.UI.Controllers
{
    public class HomeController : Controller
    {
       private readonly AppDbContext _context;
       public HomeController(AppDbContext context)
        {
            _context = context; 
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homevm = new()
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                Products = await _context.Products.ToListAsync(),
                Collections = await _context.Collections.ToListAsync(),
                Brands  = await _context.Brands.ToListAsync(),
                Images = await _context.Images.ToListAsync(),
            };
            return  View  (homevm);
        }
    }
}
