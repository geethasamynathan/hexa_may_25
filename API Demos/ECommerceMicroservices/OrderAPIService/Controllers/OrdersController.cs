using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(" Get Method of Orders Controller");
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] dynamic order) {
        return Ok(new { status = "Order Placed", OrderId = Guid.NewGuid() });
        }
    }
}
