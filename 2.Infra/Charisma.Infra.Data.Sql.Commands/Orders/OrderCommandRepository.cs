using Charisma.Core.Contracts.Orders.Commands;
using Charisma.Core.Domain.Orders.Entities;
using Charisma.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace Charisma.Infra.Data.Sql.Commands.Orders
{
    public class OrderCommandRepository :
        BaseCommandRepository<Order, CharismaCommandDbContext, int>,
        IOrderCommandRepository
    {
        public OrderCommandRepository(CharismaCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
