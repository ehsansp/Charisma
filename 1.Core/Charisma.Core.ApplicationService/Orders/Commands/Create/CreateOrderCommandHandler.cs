using Charisma.Core.Contracts.Orders.Commands;
using Charisma.Core.Domain.Orders.Entities;
using Charisma.Core.RequestResponse.Orders.Commands.Create;
using Framework.Core.ApplicationServices.Commands;
using Framework.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace Charisma.Core.ApplicationService.Orders.Commands.Create;

public class CreateOrderCommandHandler : CommandHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderCommandRepository _orderCommandRepository;

    public CreateOrderCommandHandler(ZaminServices zaminServices,
        IOrderCommandRepository orderCommandRepository) : base(zaminServices)
    {
        _orderCommandRepository = orderCommandRepository;
    }

    public override async Task<CommandResult<Guid>> Handle(CreateOrderCommand command)
    {
        Order order = Order.Create(command.CustomerId,command.OrderItems);

        await _orderCommandRepository.InsertAsync(order);

        await _orderCommandRepository.CommitAsync();

        return Ok(order.BusinessId.Value);
    }
}