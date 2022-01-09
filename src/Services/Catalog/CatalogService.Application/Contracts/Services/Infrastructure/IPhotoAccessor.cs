using Auth.Application.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Application.Contracts.Services
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResponseDto> UploadFileAsync(IFormFile file);
        Task<PhotoUploadResponseDto> UploadFilesAsync(List<IFormFile> file);
        Task<string> DeleteFileAsync(string publicId);
    }
}
