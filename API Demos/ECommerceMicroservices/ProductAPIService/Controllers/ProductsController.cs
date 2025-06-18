using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(new[]{
                new {Id=1,Name="Projector"},
                  new {Id=2,Name="Laptop"},
                  new {Id=3,Name="Ipad Air"},
            });
        }
    }
}
