using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Core.Entities;

public class Color : BaseEntity
{  
	public string? Name { get; set; }
	public string? Image { get; set; } 

	public ICollection<Product> Products { get; set; }
}
