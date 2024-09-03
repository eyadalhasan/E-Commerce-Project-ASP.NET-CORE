using SimpleProject.Models.Services.Interfaces;

namespace SimpleProject.Models.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public bool deleteFile(string path)
        {

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + path);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                return true;
            }
            return false;

        }


        public async Task<string> UploadFile(IFormFile file, string location)
        {
            try
            {


                if (file?.Length > 0)
                {
                    var path = _webHostEnvironment.WebRootPath + location + "/"; //wwwroot+images (location)
                    var extention = Path.GetExtension(file.FileName).ToLower();

                    var fileName = Guid.NewGuid().ToString().Replace(" ", "").Replace("-", "") + extention;

                    if (!Directory.Exists(path))
                    {

                        Directory.CreateDirectory(path);
                    }




                    //save 
                    using (FileStream fileStream = File.Create(path + fileName))
                    {

                        await file.CopyToAsync(fileStream);


                        return $"{location}/{fileName}";
                    }
                }
                else
                {
                    return "File not Found";
                }
            }
            catch (Exception ex)
            {
                return "problem";
            }


        }
    }
}
