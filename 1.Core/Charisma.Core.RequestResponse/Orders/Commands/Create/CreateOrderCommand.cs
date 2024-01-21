using Charisma.Core.Domain.Orders.Entities;
using Framework.Core.RequestResponse.Commands;
using Framework.Core.RequestResponse.Endpoints;

namespace Charisma.Core.RequestResponse.Orders.Commands.Create;

public class CreateOrderCommand : ICommand<Guid>, IWebRequest
{
    public int CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; }

    public string Path => "/api/Blog/Create";
}