using Foxic.Business.Services.Interfaces;
using Foxic.Business.ViewModels.AreasViewModels.ProductVM;
using Foxic.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Foxic.UI.Controllers;

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webEnv;
        private readonly IFileService _fileservice;
        public ProductController(AppDbContext context,
                                IWebHostEnvironment webEnv,
                                IFileService fileservice)
        {
            _context = context;
            _webEnv = webEnv;
            _fileservice = fileservice;
        }
        public IActionResult Index()
        {
            List<ProductListVM> products = _context.Products.Select(p => new ProductListVM()
            {
                Name = p.Name,
                Images = p.Images.FirstOrDefault(i => i.IsMain.Equals(true)).Url,
            }).ToList();

            return View(products);  
        }
         public IActionResult Create() 
         {
           ViewBag.Color = _context.Colors.ToList();
           ViewBag.Sizes = _context.Size.ToList();
            return View();
       }
    }
