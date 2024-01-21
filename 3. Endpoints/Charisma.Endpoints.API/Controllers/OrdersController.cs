using Charisma.Core.RequestResponse.Orders.Commands.Create;
using Charisma.EndPoints.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Charisma.Endpoints.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateBlog([FromBody] CreateOrderCommand command) => await Create<CreateOrderCommand, Guid>(command);
    }
}
