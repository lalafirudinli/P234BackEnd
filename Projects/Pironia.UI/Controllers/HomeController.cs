using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Pironia.DataAccess.Contexts;
using Pironia.UI.ViewModel;

namespace Pironia.UI.Controllers
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
            HomeVM homeVM = new() 
            { 
              Sliders = await _context.Sliders.ToListAsync(),
              Services = await _context.Services.ToListAsync(),

            };
            return View(homeVM);
        }
    }
}
