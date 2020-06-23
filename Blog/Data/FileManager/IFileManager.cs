using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Blog.Data.FileManager
{
    public interface IFileManager
    {
        public FileStream ImageStream(string image);
        public Task<string> SaveImage(IFormFile file);
    }
}