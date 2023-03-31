namespace APICOFFE.Services.Concretes
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile formFile, string uploadDirectory);
        string GetFileUrl(string? fileName, string uploadDirectory);
        Task DeleteAsync(string? fileName, string uploadDirectory);
    }
}
