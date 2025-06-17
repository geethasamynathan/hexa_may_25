using Authentication_Demo1.Models;
using Authentication_Demo1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductRepo _repo;
        public ProductsController(IProductRepo repo)
        {
                _repo = repo;
        }
        [HttpGet("AllProducts")]
        public async Task<IActionResult> Get() {
            try
            {
                var products = _repo.GetAllProducts();
                if(products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex )
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
        [HttpGet("productbyid/{id:int}")]           
        public async Task<IActionResult> GetProductsById(int id)
        {
            try
            {
                var products = _repo.GetProductById(id);
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }

        [HttpGet("searchbyname")]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            try
            {
                var products = _repo.GetProductByName(name);
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
        [HttpGet("searchbyprice")]
        public async Task<IActionResult> GetProductsByPrice(int price)
        {
            try
            {
                var products = _repo.SearchProductsByPrice(price);
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }

        [HttpPost("addnewproduct")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                var products = _repo.AddProduct(product);   
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }

        [HttpPut("updateproduct/{id:int}")]
       public async Task<IActionResult> CreateProduct(int id, Product product)
        {
            try
            {
                var products = _repo.UpdateProduct(id,product);
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }

        [HttpDelete("deleteproduct/{id:int}")]       
        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                var products = _repo.DeleteProduct(id);
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
    }
}
