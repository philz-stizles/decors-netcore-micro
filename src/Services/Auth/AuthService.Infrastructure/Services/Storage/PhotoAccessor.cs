using Decors.Application.Contracts.Services;
using Decors.Application.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.IO;
using Decors.Application.Settings;
using Microsoft.Extensions.Options;

namespace Decors.Infrastructure.Services.Storage
{
    public class PhotoAccessor : IPhotoAccessor
    {
        private readonly FileSettings _fileSettings;

        public PhotoAccessor(IOptions<FileSettings> fileOptions)
        {
            _fileSettings = fileOptions.Value;
        }

        public Task<string> DeleteFileAsync(string publicId)
        {
            throw new System.NotImplementedException();
        }

        public Task<PhotoUploadResponseDto> UploadFileAsync(IFormFile file)
        {
            throw new System.NotImplementedException();
        }

        public Task<PhotoUploadResponseDto> UploadFilesAsync(List<IFormFile> file)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> UploadToServerAsync(IFormFile file)
        {
            // Create upload folder if it doesn't exist yet.
            var uploadFolder = CreateUploadFolderIfNotExists();

            // Generate a random identifier to uniquely identify the image
            var guid = Guid.NewGuid();

            // Create file path.
            var filePath = Path.Combine("wwwroot",  $"{uploadFolder}/{guid}.jpg");

            // Open stream to file path.
            var fileStream = new FileStream(filePath, FileMode.Create);

            // Copy file to file path stream.
            await file.CopyToAsync(fileStream);

            // Store path to file in database.

            return filePath;
        }

        private string CreateUploadFolderIfNotExists()
        {
            var uploadFolder = _fileSettings.UploadFolders.Images;
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            return uploadFolder;
        }

        private bool ValidateFile(IFormFile file)
        {
            return true;
        }
    }
}
