using Cart.Application.Models;
using Cart.Application.Models.Responses;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Cart.Application.Contracts.Services
{
    public interface ICloudinaryService
    {
        Task<ServiceResponse<FileUploadResponseDto>> UploadFileAsync(IFormFile file);
    }
}
