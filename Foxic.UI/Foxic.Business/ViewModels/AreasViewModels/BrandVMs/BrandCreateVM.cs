using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.AreasViewModels.BrandVMs;

public class BrandCreateVM
{
    public string BrandName { get; set; } = null!;
    public IFormFile Image { get; set; }
}

