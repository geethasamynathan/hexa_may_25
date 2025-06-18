using Authentication_Demo1.DTOs;
using Authentication_Demo1.Models;

namespace Authentication_Demo1.Repository
{
    public interface IProductRepo
    {
        //public List<Product> GetAllProducts();
        public List<ProductDTO> GetAllProducts();
        public ProductDTO GetProductById(int id);
        public List<ProductDTO> GetProductByName(string name);
        public List<ProductDTO> SearchProductsByPrice(int price);
        // public string AddProduct(Product product);
        public string AddProduct(ProductCreationDTO product);
        public string UpdateProduct(int id, ProductUpdateDTO product);
        public string DeleteProduct(int id);
        List<Product> GetProductsByCategory(string category);
        List<Product> GetLowStockProducts(int threshold);
    }
}
