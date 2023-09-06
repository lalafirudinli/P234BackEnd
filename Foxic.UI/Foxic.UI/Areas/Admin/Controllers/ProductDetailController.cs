using Foxic.Business.ViewModels.AreasViewModels.ProductDetailVM;
using Foxic.Core.Entities;
using Foxic.Core.Enums;
using Foxic.DataAccess.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoxicUI.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "SuperAdmin")]
public class ProductDetailController : Controller
{
    private readonly AppDbContext _context;

    public ProductDetailController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int id)
    {
        ProductDetail productDetail = _context.ProductDetails.FirstOrDefault(p => p.Id == id);
        List<ProductDetail> productDetails = _context.ProductDetails.ToList();
        return View(productDetails);
    }
    public async Task<IActionResult> Details(int id)
    {
        ProductDetail? productDetail = await _context.ProductDetails.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (productDetail == null) return NotFound();
        return View(productDetail);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductDetailCreateVM product)
    {
        if (!ModelState.IsValid) return View(product);
        ProductDetail productDetail = new()
        {
            LongDescription = product.LongDescription,
            ShortDescription = product.ShortDescription,
            Clean = product.Clean,
            Cotton = product.Cotton,
            NonChlorine = product.NonChlorine,
            Polyester = product.Polyester,
            Tax = product.Tax,
        };
        await _context.ProductDetails.AddAsync(productDetail);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        ProductDetail? productDetail = await _context.ProductDetails.FindAsync(id);
        if (productDetail == null) return NotFound();
        return View(productDetail);
    }
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        ProductDetail? productDetail = await _context.ProductDetails.FindAsync(id);
        if (productDetail == null) return NotFound();
        _context.ProductDetails.Remove(productDetail);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int id)
    {
        ProductDetail? productDetail = await _context.ProductDetails.FindAsync(id);
        if (productDetail == null) return NotFound();
        ProductDetailUploadVM productDetailUpload = new()
        {
            Id = productDetail.Id,
            ShortDescription = productDetail.ShortDescription,
            LongDescription = productDetail.LongDescription,
            Tax = productDetail.Tax,
            Cotton = productDetail.Cotton,
            Clean = productDetail.Clean,
            NonChlorine = productDetail.NonChlorine,
            Polyester = productDetail.Polyester,
        };
        return View(productDetailUpload);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, ProductDetailUploadVM productDetail)
    {
        if (!ModelState.IsValid) return View(productDetail);
        ProductDetail? productDB = await _context.ProductDetails.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        productDB.ShortDescription = productDetail.ShortDescription;

        ProductDetail product1 = new()
        {
            Id = productDetail.Id,
            ShortDescription = productDetail.ShortDescription,
            LongDescription = productDetail.LongDescription,
            Cotton = productDetail.Cotton,
            Clean = productDetail.Clean,
            NonChlorine = productDetail.NonChlorine,
            Polyester = productDetail.Polyester,
            Tax = productDetail.Tax,
        };
        productDB = product1;
        _context.ProductDetails.Update(productDB);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}


