using Foxic.Business.Exceptions;
using Foxic.Business.Services.Interfaces;
using Foxic.Business.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.Services.Implemantations
{
	public class FileService : IFileService
	{
		public void RemoveFile(string root, string filePath)
		{
			string fileroot = Path.Combine(root, filePath);
			if (File.Exists(fileroot))
			{
				File.Delete(fileroot);
			}
		}
		public async Task<string> UploadFile(IFormFile file, string root, int kb, params string[] folders)
		{
			if (!file.CheckFileSize(kb))
			{
				throw new FileSizeException("Size ");
			}
			if (!file.CheckFileType("image"))
			{
				{
					throw new FileTypeException("Image");
				}
			}
			string folderRoot = string.Empty;
			foreach (var folder in folders)
			{
				folderRoot = Path.Combine(folderRoot, folder);
			}
			string filename = await file.UploadFile(root, folderRoot);
			return filename;
		}
	}
}
