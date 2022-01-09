using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Decors.Application.Contracts.Services;
using Decors.Application.Models;
using Decors.Application.Models.Responses;
using Decors.Application.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Services.Storage
{
    public class CloudinaryService: ICloudinaryService
    {
        private readonly CloudinarySettings _cloudinarySettings;
        private Cloudinary _cloudinary;
        public CloudinaryService(IOptions<CloudinarySettings> cloudinarySettings,
            Microsoft.Extensions.Logging.ILogger<CloudinaryService> logger)
        {
            _cloudinarySettings = cloudinarySettings.Value;

            Account acc = new Account(
                _cloudinarySettings.CloudName,
                _cloudinarySettings.ApiKey,
                _cloudinarySettings.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ServiceResponse<FileUploadResponseDto>> UploadFileAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation()
                            .Width(500)
                            .Height(500)
                            .Crop("fill")
                            .Gravity("face")
                    };

                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }
            }

            if (uploadResult.Error != null) return new ServiceResponse<FileUploadResponseDto>
            {
                Status = false,
                Message = uploadResult.Error.Message,
            };

            return new ServiceResponse<FileUploadResponseDto>
            {
                Status = true,
                Data = new FileUploadResponseDto
                {
                    Url = uploadResult.Url.ToString(),
                    PublicId = uploadResult.PublicId
                }
            };
        }
    }
}
