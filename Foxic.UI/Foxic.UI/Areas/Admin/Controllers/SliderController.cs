using AutoMapper;
using Foxic.Business.Exceptions;
using Foxic.Business.Services.Implemantations;
using Foxic.Business.Services.Interfaces;
using Foxic.Business.ViewModels.SliderViewModels;
using Foxic.Core.Entities;
using Foxic.Core.Entities.Areas;
using Foxic.DataAccess.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

[Area("Admin")]
[Authorize(Roles = "SuperAdmin")]
public class SliderController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webEnv;
    private readonly IFileService _fileservice;
    public SliderController(AppDbContext context,
                            IMapper mapper,
                            IWebHostEnvironment webEnv,
                            IFileService fileservice)
    {
        _context = context;
        _mapper = mapper;
        _webEnv = webEnv;
        _fileservice = fileservice;
    }

    public IActionResult Index()
    {
        var sliders = _context.Sliders.AsNoTracking();
        ViewBag.Count = sliders.Count();
        return View(sliders);
    }
    public async Task<IActionResult> Details(int id)
    {
        Slider? slider = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        if (slider == null) return NotFound();
        return View(slider);
    }
    
    public IActionResult Create()
    {
        if (_context.Sliders.Count() >= 5)
        {
            return BadRequest();
        }

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SliderPostVM slider)
    {
        if (!ModelState.IsValid) return View(slider);
        string filename = string.Empty;
        try
        {
            filename = await _fileservice.UploadFile(slider.ImageUrl, _webEnv.WebRootPath, 300, "assets", "images", "slider");
            Slider newslider = _mapper.Map<Slider>(slider);
            newslider.ImageUrl = filename;
            await _context.Sliders.AddAsync(newslider);
            await _context.SaveChangesAsync();
        }
        catch (FileSizeException ex)
        {
            ModelState.AddModelError("SliderImage", ex.Message);
            return View(slider);
        }
        catch (FileTypeException ex)
        {
            ModelState.AddModelError("SliderImage", ex.Message);
            return View(slider);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(slider);
        }

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        Slider? slider = await _context.Sliders.FindAsync(id);
    
        if (slider == null) return NotFound();
        return View(slider);
    }
    [HttpPost]
    [ActionName("Delete")] 
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        Slider? slider = await _context.Sliders.FindAsync(id);
        if (slider == null) return NotFound();
       
        string fileroot = Path.Combine(_webEnv.WebRootPath, slider.ImageUrl);
        if (System.IO.File.Exists(fileroot))
        {
            System.IO.File.Delete(fileroot);
        }

        _context.Sliders.Remove(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
       
    }

    public async Task<IActionResult> Update(int id)
    {
        Slider? slider = await _context.Sliders.FindAsync(id);
        if (slider == null) return NotFound();
      
        SliderUploadVM sliderUploadVM = _mapper.Map<SliderUploadVM>(slider);
        return View(sliderUploadVM);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, SliderUploadVM slider)
    {
        if (!ModelState.IsValid) return View(slider);
        Slider? sliderdb = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        if (sliderdb == null) return NotFound();
        if (slider.Image != null)
        {
            try
            {
                string filename = await _fileservice.UploadFile(slider.Image, _webEnv.WebRootPath, 300, "assets", "images", "slider");
                _fileservice.RemoveFile(_webEnv.WebRootPath, sliderdb.ImageUrl);
                sliderdb = _mapper.Map<Slider>(slider);
                sliderdb.ImageUrl = filename;
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError("Image", ex.Message);
                return View(slider);
            }
            catch (FileTypeException ex)
            {
                ModelState.AddModelError("Image", ex.Message);
                return View(slider);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(slider);
            }
        }
        else
        {
            slider.ImageUrl = sliderdb.ImageUrl;
            sliderdb = _mapper.Map<Slider>(slider);
        }
      
        _context.Sliders.Update(sliderdb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}