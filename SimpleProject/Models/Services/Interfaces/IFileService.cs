namespace SimpleProject.Models.Services.Interfaces
{
    public interface IFileService
    {
        public Task<string> UploadFile(IFormFile file, string location);
        public bool deleteFile(string path);

    }
}
