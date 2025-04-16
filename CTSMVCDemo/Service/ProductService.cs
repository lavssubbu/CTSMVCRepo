using CTSMVCDemo.Models;
using CTSMVCDemo.Repository;
using Microsoft.EntityFrameworkCore;

namespace CTSMVCDemo.Service
{
    public class ProductService : IProduct, ICategory
    {
        private readonly ProductDbContext _context;

        public ProductService(ProductDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            IEnumerable<Category> cat = _context.Category.Include(p=>p.Products).ToList();
            return cat;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> prod = _context.Products.Include(c=>c.category).ToList();
            return prod;
        }

        public Product GetProductById(int id) => _context.Products.Find(id);

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existing = _context.Products.FirstOrDefault(p => p.proId == product.proId);
            if (existing != null)
            {
                // update manually
                existing.proName = product.proName;
                existing.price = product.price;
                existing.categoryId = product.categoryId;

                _context.SaveChanges();
            }
           
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public Category GetCategoryById(int id) =>
       _context.Category.Find(id);

        public void AddCategory(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Category.Find(id);
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
