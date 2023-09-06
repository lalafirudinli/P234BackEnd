using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.AreasViewModels.CategoryVM;

public class CategoryListVM
{

    [Required, MaxLength(100), MinLength(3)]
    public string CategoryName { get; set; }
}
