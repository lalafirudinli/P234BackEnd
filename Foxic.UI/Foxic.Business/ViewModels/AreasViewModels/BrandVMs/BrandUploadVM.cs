using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.AreasViewModels.BrandVMs;

public class BrandUploadVM
{

    public int Id { get; set; }

    [Required, MaxLength(50), MinLength(3)]
    public string BrandName { get; set; } = null!;

    public IFormFile? Image { get; set; }

    public string? BrandImage { get; set; }
}
