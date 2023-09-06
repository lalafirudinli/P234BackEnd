using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.AreasViewModels.ProductDetailVM;

public class ProductDetailCreateVM
{
    [Required, MaxLength(200), MinLength(10)]
    public string ShortDescription { get; set; }

    [Required, MaxLength(250), MinLength(20)]
    public string LongDescription { get; set; }

    public bool Cotton { get; set; }
    public bool Polyester { get; set; }
    public bool Clean { get; set; }
    public bool NonChlorine { get; set; }
    public bool Tax { get; set; }
}
