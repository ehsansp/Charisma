using Framework.Core.Domain.Events;

namespace Charisma.Core.Domain.Orders.Events;

public record OrderCreated(Guid BusinessId,
    int CustomerId,decimal TotalAmount) : IDomainEvent;