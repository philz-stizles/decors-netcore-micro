using Cart.Application.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cart.Application.Contracts.Services
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResponseDto> UploadFileAsync(IFormFile file);
        Task<PhotoUploadResponseDto> UploadFilesAsync(List<IFormFile> file);
        Task<string> DeleteFileAsync(string publicId);
    }
}
