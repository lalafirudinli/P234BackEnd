using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pironia.Business.ViewModels.SliderViewModels;

public class SliderPostVM
{
    [Required(ErrorMessage ="Upss Danger!"), MaxLength(30), MinLength(10)]
    public string Title { get; set; } = null!;
    [Required,MaxLength(100)]
    public string Description { get; set; } = null!;
    public int Discount { get; set; }
    [Required]  
    public IFormFile ImageUrl { get; set; } = null!;

}
