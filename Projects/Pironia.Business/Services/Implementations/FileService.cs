using Microsoft.AspNetCore.Http;
using Pironia.Business.Exceptions;
using Pironia.Business.Services.Interfaces;
using Pironia.Business.Utilities;
using Pironia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pironia.Business.Services.Implementations
{
    public class FileService : İFileService
    {
        public void RemoveFile(string root, string filePath)
        {
            string fileRoot = Path.Combine(root, filePath);

            if (File.Exists(fileRoot))
            {
                File.Delete(fileRoot);
            }
        }

        public async Task<string> UploadFile(IFormFile file, string root,int kb, params string[] folders)
        {
            if (!file.CheckFileSize(kb))
            {
                throw new FileSizeException("File size must be less than 300kb");
            }

            if (!file.CheckFileType("image"))
            {
                throw new FileTypeException("Please select image type");
            }
            string folderRoot =  string.Empty;
            foreach (var folder in folders)
            {
                folderRoot = Path.Combine(root, folderRoot);
            }


            string fileName = await file.UploadFile(root, folderRoot);
            return fileName;    
        }
    }
}
