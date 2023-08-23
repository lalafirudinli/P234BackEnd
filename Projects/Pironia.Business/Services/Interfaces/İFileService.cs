using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pironia.Business.Services.Interfaces;

public interface İFileService
{
    Task<string> UploadFile( IFormFile file,string root, int kb, params string[] folders);
    void RemoveFile(string root, string filePath);
}
