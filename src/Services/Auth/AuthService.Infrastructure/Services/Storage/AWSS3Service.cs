using Decors.Application.Contracts.Services;
using Decors.Application.Models;
using Decors.Application.Models.Responses;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Services.Storage
{
    public class AWSS3Service : IAWSS3Service
    {
        public Task<CreateS3BucketResponseDto> CreateBucketAsync(string bucketName = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DoesS3BucketExistAsync(string bucketName = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<ExecutionResponse<string>> UploadFileAsync(byte[] fileStream, string fileName, string bucketName = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<ExecutionResponse<string>> UploadFileAsync(Stream fileStream, string fileName, string bucketName = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseResponse> UploadFileAsync(IFormFile file, int id, string bucketName = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
