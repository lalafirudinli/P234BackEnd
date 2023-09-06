using Foxic.Business.Exceptions;
using Foxic.Business.Services.Interfaces;
using Foxic.Business.ViewModels.AreasViewModels.BrandVMs;
using Foxic.Business.ViewModels.AreasViewModels.CollectionVM;
using Foxic.Core.Entities;
using Foxic.Core.Enums;
using Foxic.DataAccess.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace FoxicUI.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "SuperAdmin")]
public class CollectionController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _webEnv;
    private readonly IFileService _fileservice;
    public CollectionController(AppDbContext context,
                            IWebHostEnvironment webEnv,
                            IFileService fileservice)
    {
        _context = context;
        _webEnv = webEnv;
        _fileservice = fileservice;
    }
    public IActionResult Collection(int Id)
    {
        Collections collections = _context.Collections.FirstOrDefault(c => c.Id == Id);
        List<Collections> collection = _context.Collections.ToList();
        return View(collection);
    }
    public async Task<IActionResult> Details(int id)
    {
        Collections? collection = await _context.Collections.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        if (collection == null) return NotFound();
        return View(collection);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CollectionCreateVM collection)
    {
        if (!ModelState.IsValid) return View(collection);
        string filename = string.Empty;
        try
        {
            Collections collection2 = new()
            {
                CollectionName = collection.CollectionName
            };
            filename = await _fileservice.UploadFile(collection.Image, _webEnv.WebRootPath, 300, "assets", "images", "slider");
            collection2.Image = filename;
            await _context.Collections.AddAsync(collection2);
            await _context.SaveChangesAsync();
        }
        catch (FileSizeException ex)
        {
            ModelState.AddModelError("CollectionImage", ex.Message);
            return View(collection);
        }
        catch (FileTypeException ex)
        {
            ModelState.AddModelError("CollectionImage", ex.Message);
            return View(collection);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(collection);
        }
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        Collections? collection = await _context.Collections.FindAsync(id);
        if (collection == null) return NotFound();
        return View(collection);
    }
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        Collections? collection = await _context.Collections.FindAsync(id);
        if (collection == null) return NotFound();
        string fileroot = Path.Combine(_webEnv.WebRootPath, collection.Image);
        if (System.IO.File.Exists(fileroot))
        {
            System.IO.File.Delete(fileroot);
        }
        _context.Collections.Remove(collection);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }
    public async Task<IActionResult> Update(int id)
    {
        Collections? collection = await _context.Collections.FindAsync(id);
        if (collection == null) return NotFound();
        CollectionUploadVM collectionUpload = new()
        {
            Id = collection.Id,
            CollectionName = collection.CollectionName,
            CollectionImage = collection.Image,
        };
        return View(collectionUpload);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, CollectionUploadVM collection)
    {
        if (!ModelState.IsValid) return View(collection);
        Collections? collectiondb = await _context.Collections.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (collectiondb == null) return NotFound();
        if (collection.Image != null)
        {
            try
            {
                string filename = await _fileservice.UploadFile(collection.Image, _webEnv.WebRootPath, 300, "assets", "images", "slider");
                _fileservice.RemoveFile(_webEnv.WebRootPath, collectiondb.Image);
                Collections collections = new()
                {
                    Id = collection.Id,
                    CollectionName = collection.CollectionName,
                    Image = collection.CollectionImage
                };
                collectiondb = collections;
                collectiondb.Image = filename;
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError("Image", ex.Message);
                return View(collection);
            }
            catch (FileTypeException ex)
            {
                ModelState.AddModelError("Image", ex.Message);
                return View(collection);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(collection);
            }
        }
        else
        {
            collection.CollectionImage = collectiondb.Image;
            Collections collections = new()
            {
                Id = collection.Id,
                CollectionName = collection.CollectionName,
                Image = collection.CollectionImage
            };
            collectiondb = collections;
        }
        _context.Collections.Update(collectiondb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
    




 
   
        