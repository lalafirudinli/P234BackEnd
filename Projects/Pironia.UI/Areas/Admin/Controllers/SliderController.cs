using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pironia.Business.ViewModels.SliderViewModels;
using Pironia.Core.Entities;
using Pironia.DataAccess.Contexts;
using Pironia.Business.Utilities;
using Pironia.Business.Services.Interfaces;
using System.Xml.Linq;
using Pironia.Business.Exceptions;

namespace Pironia.UI.Areas.Admin.Controllers;

[Area("Admin")]
public class SliderController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webEnv;
    private readonly İFileService _fileService;


    public SliderController(AppDbContext context, IMapper mapper,IWebHostEnvironment webEnv, İFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _webEnv = webEnv;
        _fileService = fileService;
    }

    public IActionResult Index()
    {
        var sliders = _context.Sliders.AsNoTracking();
        ViewBag.Count= sliders.Count();
        return View(sliders);
    }

    public async Task<IActionResult> Detail(int id) 
    {
        Slider? slider = await _context.Sliders.FindAsync(id);
        slider.Title = "Test";
        if (slider == null) return NotFound();
        return View(slider);

    }
    public IActionResult Create() 
    {    if(_context.Sliders.Count() >= 5)
        {
            return BadRequest();
        }
        return View();
    
    }

    [HttpPost]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Create(SliderPostVM slider) 
    {  
        if(!ModelState.IsValid) return View(slider);
        string fileName = string.Empty;
        try
        {
            fileName = await _fileService.UploadFile(slider.ImageUrl, _webEnv.WebRootPath,300 ,"assets", "images", "website=images");
        }
        catch (FileSizeException ex)
        {

            ModelState.AddModelError("ImageUrl", ex.Message);
            return View(slider);
        }

        catch (FileTypeException ex) 
        {
            ModelState.AddModelError("ImageUrl",ex.Message );
            return View(slider);
        }
        catch (Exception ex) 
        {
            ModelState.AddModelError("", ex.Message);
            return View(slider);
        }

        //

        Slider newSlider = _mapper.Map<Slider>(slider);
        newSlider.ImageUrl = fileName;

        await _context.Sliders.AddAsync(newSlider);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
     public async Task<IActionResult> Delete(int id) 
    {
        Slider slider = await _context.Sliders.FindAsync(id);
        if (slider != null) return NotFound();
        return View(slider);
    }

    [HttpPost]
    [ActionName("Delete")]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        Slider? slider = await _context.Sliders.FindAsync(id);

        if (slider == null) 
        {
            return NotFound();
        }
        string fileRoot = Path.Combine(_webEnv.WebRootPath, slider.ImageUrl);
     
        if (System.IO.File.Exists(fileRoot)) 
        {
           System.IO.File.Delete(slider.ImageUrl);
        }
        
        _context.Sliders.Remove(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

   
}
