using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.Services.Interfaces;

public interface IFileService
{
	Task<string> UploadFile(IFormFile file, string root, int kb, params string[] folders);
	public void RemoveFile(string root, string filePath);


}
