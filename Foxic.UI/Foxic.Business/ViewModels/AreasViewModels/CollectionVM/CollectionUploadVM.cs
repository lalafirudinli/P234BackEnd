using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.ViewModels.AreasViewModels.CollectionVM;

public class CollectionUploadVM
{
    public int Id { get; set; }
    [Required, MaxLength(100),  MinLength(3)]
    public string? CollectionName { get; set; } = null!;
    public IFormFile? Image { get; set; }
    public string? CollectionImage { get; set; }
}

