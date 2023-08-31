using CoreAuthentication.Models;

namespace CoreAuthentication.Interface
{
    public interface IProduct
    {
        //Implement the code here

        Task<List<Product>> GetAllProductAsync();

        Task<Product> CreateAsync(Product product);

        Task<Product?> UpdateAsync(int Id, Product product);
        
        Task<Product?> DeleteAsync(int Id);
    }
}
