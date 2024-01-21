using Charisma.Core.Domain.Products.Entities;
using Framework.Core.Domain.Entities;

namespace Charisma.Core.Domain.Orders.Entities;

public class OrderItem : Entity<int>
{
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal TotalPrice => Product.Price * Quantity;

    public OrderItem(Product product, int quantity)
    {
        // Additional validation logic if needed
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
        }

        // Additional business rules if needed

        // Set properties
        Product = product;
        Quantity = quantity;
    }
}