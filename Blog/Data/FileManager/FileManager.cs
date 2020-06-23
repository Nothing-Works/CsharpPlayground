using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Blog.Data.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly IConfiguration _config;

        public FileManager(IConfiguration config)
        {
            _config = config;
        }

        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_config["Path:Images"], image), FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile file)
        {
            var savePath = Path.Combine(_config["Path:Images"]);

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            var mime = file.FileName.Substring(file.FileName.LastIndexOf('.'));
            var fileName = $"img_{DateTime.UtcNow:dd-MM-yyyy-HH-mm-ss}{mime}";

            await using var fileStream = new FileStream(Path.Combine(savePath, fileName), FileMode.Create);
            await file.CopyToAsync(fileStream);

            return fileName;
        }
    }
}