using Auth.Application.Models;
using Auth.Application.Models.Responses;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Auth.Application.Contracts.Services
{
    public interface ICloudinaryService
    {
        Task<ServiceResponse<FileUploadResponseDto>> UploadFileAsync(IFormFile file);
    }
}
