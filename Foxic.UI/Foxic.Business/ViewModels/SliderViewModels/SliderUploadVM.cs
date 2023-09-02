using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.SliderViewModels;

public class SliderUploadVM
{  
	public int Id { get; set; }	

	[Required, MaxLength(30), MinLength(5)]
	public string? Title { get; set; } = null!;
	[Required, MaxLength(100)]
	public string? Description { get; set; } = null!;
	[Required]
	public IFormFile? Image { get; set; }
	public string? ImageUrl { get; set; } 

}
