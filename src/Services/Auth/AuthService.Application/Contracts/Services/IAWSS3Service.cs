using Auth.Application.Models;
using Auth.Application.Models.Responses;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Auth.Application.Contracts.Services
{
    public interface IAWSS3Service
    {
        Task<bool> DoesS3BucketExistAsync(string bucketName = null);
        Task<CreateS3BucketResponseDto> CreateBucketAsync(string bucketName = null);
        Task<ExecutionResponse<string>> UploadFileAsync(byte[] fileStream,
            string fileName, string bucketName = null);
        Task<ExecutionResponse<string>> UploadFileAsync(Stream fileStream, string fileName,
            string bucketName = null);
        Task<BaseResponse> UploadFileAsync(IFormFile file, int id, string bucketName = null);
    }
}
