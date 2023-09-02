using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Foxic.Business.ViewModels.SliderViewModels;

public class SliderPostVM
{
	[Required, MaxLength(30), MinLength(5)]
	public string Title { get; set; } = null!;
	[Required, MaxLength(100)]
	public string Description { get; set; } = null!;
	[Required]
	public IFormFile ImageUrl { get; set; }= null!;

}
