using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Foxic.Business.ViewModels.AreasViewModels.ColorVMs;

public class ColorCreateVM
{
	[Required]
	public string ColorName { get; set; } = null!;
	[Required]
	public IFormFile? ColorImage { get; set; }
}

