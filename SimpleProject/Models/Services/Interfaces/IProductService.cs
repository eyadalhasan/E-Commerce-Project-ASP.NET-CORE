namespace SimpleProject.Models.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();
        public Task<Product?> GetProductById(int id);
        public Task<string> AddProduct(Product product);
        public Task<string> DeleteProduct(Product product);
        public Task<string> UpdateProduct(Product product);
        public Task<bool> IsProductNameExist(string name);



    }
}
