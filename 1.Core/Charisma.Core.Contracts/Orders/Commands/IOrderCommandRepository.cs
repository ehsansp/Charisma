using System.Reflection.Metadata;
using Charisma.Core.Domain.Orders.Entities;
using Framework.Core.Contracts.Data.Commands;

namespace Charisma.Core.Contracts.Orders.Commands;

public interface IOrderCommandRepository : ICommandRepository<Order, int>
{
    
}