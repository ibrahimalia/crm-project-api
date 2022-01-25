using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

namespace Meta.IntroApp.Services.UploadFiles
{
    public interface IUploadFileService
    {

        Task<string> UploadFileAsync(IFormFile file);
        Task<string> UploadAttachement(IFormFile file);

    }
}
