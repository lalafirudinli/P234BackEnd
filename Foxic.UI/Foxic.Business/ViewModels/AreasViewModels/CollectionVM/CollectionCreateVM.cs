using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.AreasViewModels.CollectionVM;

public class CollectionCreateVM
{
    public string CollectionName { get; set; } = null!;
    public IFormFile Image { get; set; }
}