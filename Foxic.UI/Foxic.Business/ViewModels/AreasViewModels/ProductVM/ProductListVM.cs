using Foxic.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.AreasViewModels.ProductVM;

public class ProductListVM
{
    public string? Name { get; set; }
    public int Discount { get; set; }
    public int Stock {get; set; }
    public double Price { get; set; }
    public Category Category { get; set; }
    public Collections Collections { get; set; }
    public Brand Brand { get; set; }
    public string Images { get; set; }
    public IFormFile MainImage { get; set; }   
   
}

