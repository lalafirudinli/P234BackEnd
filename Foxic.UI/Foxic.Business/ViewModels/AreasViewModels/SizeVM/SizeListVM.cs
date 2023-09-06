using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.AreasViewModels.SizeVM;

public class SizeListVM
{
    [Required]
    public string SizeName { get; set; } = null!;
}
