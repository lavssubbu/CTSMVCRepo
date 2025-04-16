using CTSMVCDemo.Models;

namespace CTSMVCDemo.Repository
{
    public interface IProduct
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
