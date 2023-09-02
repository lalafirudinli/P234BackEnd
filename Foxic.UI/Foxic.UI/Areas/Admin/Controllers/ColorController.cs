using Foxic.Business.Services.Interfaces;
using Foxic.Business.ViewModels.AreasViewModels.ColorVMs;
using Foxic.Core.Entities;
using Foxic.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FoxicUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ColorController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _webEnv;
    private readonly IFileService _fileservice;
    public ColorController(AppDbContext context,
                            IWebHostEnvironment webEnv,
                            IFileService fileservice)
    {
        _context = context;
        _webEnv = webEnv;
        _fileservice = fileservice;
    }
    public IActionResult Index(int Id)
    {
        Color color = _context.Colors.FirstOrDefault(x => x.Id == Id);
        List<Color> colors = _context.Colors.ToList();
        return View(colors);
    }
    public async Task<IActionResult> Details(int id)
    {
        Color? color = await _context.Colors.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        if (color == null) return NotFound();
        return View(color);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ColorCreateVM color)
    {
        string filename = string.Empty;

        Color color1 = new()
        {
            Name = color.ColorName
        };
        filename = await _fileservice.UploadFile(color.ColorImage, _webEnv.WebRootPath, 300, "assets", "images", "slider");
        color1.Image = filename;
        await _context.Colors.AddAsync(color1);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}