using Foxic.Core.Entities;
using Foxic.Core.Entities.Areas;

namespace Foxic.UI.ViewModels.HomeVM;

public class HomeVM
{
    public List<Slider> Sliders { get; set; } = null!;
    public List<Category> Categories { get; set; } = null!;
    public List<Collections> Collections { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
    public List<Image> Images { get; set; } = null!;
    public List<Brand> Brands { get; set; } = null!;    

}

