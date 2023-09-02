
using Foxic.Business.Services.Interfaces;
using Foxic.Business.ViewModels.AreasViewModels.BrandVMs;
using Foxic.Core.Entities;
using Foxic.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoxicUI.Areas.Admin.Controllers;
[Area("Admin")]
public class BrandController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _webEnv;
    private readonly IFileService _fileservice;
    public BrandController(AppDbContext context,
                            IWebHostEnvironment webEnv,
                            IFileService fileservice)
    {
        _context = context;
        _webEnv = webEnv;
        _fileservice = fileservice;
    }
    public IActionResult Index(int Id)
    {
        Brand brand = _context.Brands.FirstOrDefault(b => b.Id == Id);
        List<Brand> brands = _context.Brands.ToList();
        return View(brands);
    }
    public async Task<IActionResult> Details(int id)
    {
        Brand? brand = await _context.Brands.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        if (brand == null) return NotFound();
        return View(brand);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BrandCreateVM brand)
    {
        string filename = string.Empty;

        Brand brand2 = new()
        {
            BrandName = brand.BrandName
        };
        filename = await _fileservice.UploadFile(brand.Image, _webEnv.WebRootPath, 300, "assets", "images", "slider");
        brand2.Image = filename;
        await _context.Brands.AddAsync(brand2);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}