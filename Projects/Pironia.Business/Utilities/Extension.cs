using Microsoft.AspNetCore.Http;
using Pironia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pironia.Business.Utilities;

public static class Extension
{
    public static bool CheckFileSize( this IFormFile file, int kb) 
    {
        return file.Length / 1024 <= kb;
    }

    public static bool CheckFileType( this IFormFile file, string filyType) 
    {
        return file.ContentType.Contains(filyType);
    }

    public static async Task<string> UploadFile(this IFormFile file,
        string root, 
        string foldersRoot)
    {

       string name = Guid.NewGuid().ToString() + file.FileName;
      
        string fileName = Path.Combine(foldersRoot, name);

        string fileRoot = Path.Combine(root, fileName);
        using (FileStream fileStream = new FileStream(fileRoot, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
        return fileName;
    }
}
