using Microsoft.AspNetCore.Http;

namespace Weblog.Framework.Contracts
{
    public interface IFileService
    {
        public string Upload(IFormFile file, string folder);
    }
}