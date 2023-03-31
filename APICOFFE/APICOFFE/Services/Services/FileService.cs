using APICOFFE.Services.Concretes;

namespace APICOFFE.Services.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService>? _logger;

        public FileService(ILogger<FileService>? logger)
        {
            _logger = logger;
        }
        public async Task<string> UploadAsync(IFormFile formFile, string uploadDirectory)
        {
            string directoryPath = GetUploadDirectory(uploadDirectory);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var imageNameInSystem = GenerateUniqueFileName(formFile.FileName);
            var filePath = Path.Combine(directoryPath, imageNameInSystem);

            try
            {
                using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                await formFile.CopyToAsync(fileStream);
            }
            catch (Exception e)
            {
                _logger!.LogError(e, "Error occured in file service");

                throw;
            }

            return imageNameInSystem;
        }

        public async Task DeleteAsync(string? fileName, string uploadDirectory)
        {
            ArgumentNullException.ThrowIfNull(fileName);
            var deletePath = Path.Combine(GetUploadDirectory(uploadDirectory), fileName!);

            await Task.Run(() => File.Delete(deletePath));
        }

        private string GetUploadDirectory(string uploadDirectory)
        {
            string startPath = Path.Combine("wwwroot", "client", "custom-files");
            return Path.Combine(startPath, uploadDirectory);
        }

        private string GenerateUniqueFileName(string fileName)
        {
            return $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
        }

        public string GetFileUrl(string? fileName, string uploadDirectory)
        {
            string initialSegment = "client/custom-files/";
            return $"{initialSegment}/{uploadDirectory}/{fileName}";
        }
    }
}
