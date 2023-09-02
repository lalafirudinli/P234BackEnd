using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Core.Entities.Areas;

public class Slider :BaseEntity
{
	[Required, MaxLength(30), MinLength(5)]
	public string? Title { get; set; } = null!;
	[Required, MaxLength(100)]
	public string? Description { get; set; } = null!;
	[Required]
	public string? ImageUrl { get; set; } = null!;

}
