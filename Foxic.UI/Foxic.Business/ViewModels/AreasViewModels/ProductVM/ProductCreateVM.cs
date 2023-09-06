using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.AreasViewModels.ProductVM;

public class ProductCreateVM
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public int CollectionId { get; set; }
    public int DetailId { get; set; }
    public List<int> ColorIds { get; set; }
    public List<int> SizeIds { get; set; }
    public IFormFile MainImage { get; set; }
    public List<IFormFile> Images { get; set; }

}
