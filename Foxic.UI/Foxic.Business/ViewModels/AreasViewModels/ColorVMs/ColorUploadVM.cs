using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.AreasViewModels.ColorVMs;

public class ColorUploadVM
{
    public int Id { get; set; }
    [Required]
    public string ColorName { get; set; } = null!;
    public string? ColorImage { get; set; }
    public IFormFile? Image { get; set; }

}
