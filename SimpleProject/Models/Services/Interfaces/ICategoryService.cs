namespace SimpleProject.Models.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoriesAsync();

    }
}
