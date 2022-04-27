using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ProjectCRUD.Repository
{
    public class ImageRepository : IImageInterface
    {
        public async Task<string> uploadImage(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"ImagesAndFiles\Images", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetServerPath(fileName); 

        }
        private  string GetServerPath(string fileName)
        {
            return Path.Combine(@"ImagesAndFiles\Images", fileName);
        }
    }
}
