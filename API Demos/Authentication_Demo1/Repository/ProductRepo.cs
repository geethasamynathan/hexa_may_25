using Authentication_Demo1.Contexts;
using Authentication_Demo1.DTOs;
using Authentication_Demo1.Models;
using AutoMapper;

namespace Authentication_Demo1.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;
        public ProductRepo(ProductContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public string AddProduct(Product product)
        //{
        //    try
        //    {
        //        if (product != null)
        //        {
        //            product.CreatedDate = DateTime.Now;
        //            _context.Products.Add(product);
        //            _context.SaveChanges();
        //            return " Product Added successfully";
        //        }
        //        else
        //            return "Enter  product details properly";
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        public string AddProduct(ProductCreationDTO productDTO)
        {
            try
            {
                if (productDTO != null)
                {
                    var product = new Product
                    {
                        Name = productDTO.Name,
                        SKU = productDTO.SKU,
                        Category = productDTO.Category,
                        Manufacturing_Cost = productDTO.Manufacturing_Cost,
                        Selling_Price = productDTO.Selling_Price,
                        StockQuantity = productDTO.StockQuantity,
                        ProductImageUrl = productDTO.ProductImageUrl,
                        ManufacturedDate = productDTO.ManufacturedDate,
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    };

                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return "Product added successfully";
                }
                else
                {
                    return "Enter product details properly";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in AddProduct: {ex.Message}");
            }
        }


        public string DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.Where(p => p.Id==id).FirstOrDefault();

              //  var newProduct=_mapper.Map<Product>(product);
                if (product != null)
                {
                    product.IsActive = false;
                    product.UpdatedDate = DateTime.UtcNow;
                    _context.SaveChanges();
                    return "Product marked as inactive (soft deleted)";
                }
                return $"Product with Id {id} not found";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public List<Product> GetAllProducts()
        //{
        //    try
        //    {
        //        return _context.Products.Where(p => p.IsActive).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Exception in GetAllProducts: {ex.Message}");
        //    }
        //}

        public List<ProductDTO> GetAllProducts()
        {
            try
            {
                return _context.Products
                    .Where(p => p.IsActive)
                    .Select(p => new ProductDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        SKU = p.SKU,
                        Category = p.Category,
                        Selling_Price = p.Selling_Price,
                        StockQuantity = p.StockQuantity,
                        ProductImageUrl = p.ProductImageUrl
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllProducts: {ex.Message}");
            }
        }

        public ProductDTO GetProductById(int id)
        {
            try
            {
                var product= _context.Products.FirstOrDefault(p => p.Id == id && p.IsActive);
                if (product != null)
                    return _mapper.Map<ProductDTO>(product);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductById: {ex.Message}");
            }
        }

        public List<ProductDTO> GetProductByName(string name)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return _context.Products
                        .Where(p => p.Name.ToLower().Contains(name.ToLower()) && p.IsActive)
                         .Select(p => new ProductDTO
                         {
                             Id = p.Id,
                             Name = p.Name,
                             SKU = p.SKU,
                             Category = p.Category,
                             Selling_Price = p.Selling_Price,
                             StockQuantity = p.StockQuantity,
                             ProductImageUrl = p.ProductImageUrl
                         })
                        .ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductByName: {ex.Message}");
            }
        }

        public List<ProductDTO> SearchProductsByPrice(int price)
        {
            try
            {
                return _context.Products
                    .Where(p => p.Selling_Price >= price && p.IsActive)
                     .Select(p => new ProductDTO
                     {
                         Id = p.Id,
                         Name = p.Name,
                         SKU = p.SKU,
                         Category = p.Category,
                         Selling_Price = p.Selling_Price,
                         StockQuantity = p.StockQuantity,
                         ProductImageUrl = p.ProductImageUrl
                     })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in SearchProductsByPrice: {ex.Message}");
            }
        }

        //public string UpdateProduct(int id, Product product)
        //{
        //    try
        //    {
        //        var existingProduct = GetProductById(id);
        //        if (existingProduct == null)
        //            return $"Product with Id {id} not found";

        //        existingProduct.Name = product.Name;
        //        existingProduct.SKU = product.SKU;
        //        existingProduct.Category = product.Category;
        //        existingProduct.Manufacturing_Cost = product.Manufacturing_Cost;
        //        existingProduct.Selling_Price = product.Selling_Price;
        //        existingProduct.StockQuantity = product.StockQuantity;
        //        existingProduct.ManufacturedDate = product.ManufacturedDate;
        //        existingProduct.ProductImageUrl = product.ProductImageUrl;
        //        existingProduct.IsActive = product.IsActive;
        //        existingProduct.UpdatedDate = DateTime.UtcNow;

        //        _context.SaveChanges();
        //        return $"Product with Id {id} updated successfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Exception in UpdateProduct: {ex.Message}");
        //    }
        //}

        public string UpdateProduct(int id, ProductUpdateDTO productDTO)
        {
            try
            {
                var existingProduct= _context.Products.Where(p => p.Id==id).FirstOrDefault();
              
                if (existingProduct == null)
                    return $"Product with Id {id} not found";

                existingProduct.Name = productDTO.Name;
                existingProduct.SKU = productDTO.SKU;
                existingProduct.Category = productDTO.Category;
                existingProduct.Manufacturing_Cost = productDTO.Manufacturing_Cost;
                existingProduct.Selling_Price = productDTO.Selling_Price;
                existingProduct.StockQuantity = productDTO.StockQuantity;
                existingProduct.ProductImageUrl = productDTO.ProductImageUrl;
                existingProduct.ManufacturedDate = productDTO.ManufacturedDate;
                existingProduct.IsActive = productDTO.IsActive;
                existingProduct.UpdatedDate = DateTime.UtcNow;
              
                _context.SaveChanges();
                return $"Product with Id {id} updated successfully";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateProduct: {ex.Message}");
            }
        }

        public List<Product> GetProductsByCategory(string category)
        {
            try
            {
                return _context.Products
            .Where(p => p.Category.ToLower() == category.ToLower() && p.IsActive)
            .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductsByCategory: {ex.Message}");
            }
        }

        public List<Product> GetLowStockProducts(int threshold)
        {
            try
            {
                return _context.Products
                    .Where(p => p.StockQuantity <= threshold && p.IsActive)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetLowStockProducts: {ex.Message}");
            }
        }

        //List<ProductDTO> IProductRepo.GetProductByName(string name)
        //{
        //    throw new NotImplementedException();
        //}

        //List<ProductDTO> IProductRepo.SearchProductsByPrice(int price)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
