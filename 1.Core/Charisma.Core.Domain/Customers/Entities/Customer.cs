using Framework.Core.Domain.Entities;

namespace Charisma.Core.Domain.Customers.Entities;

public class Customer : AggregateRoot<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}