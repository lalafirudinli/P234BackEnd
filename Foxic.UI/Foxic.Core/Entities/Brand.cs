using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Core.Entities;

public  class Brand : BaseEntity
{
    [Required]
    public string? BrandName { get; set; }
    [Required]
    public string? Image { get; set; }
    [Required]
    public ICollection<Product> Products { get; set; }  
}
