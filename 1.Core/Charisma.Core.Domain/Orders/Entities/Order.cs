using Charisma.Core.Domain.Orders.Events;
using Charisma.Core.Domain.Products.Entities;
using Framework.Core.Domain.Entities;
using Framework.Core.Domain.Exceptions;

namespace Charisma.Core.Domain.Orders.Entities;

public class Order : AggregateRoot<int>
{
    public int CustomerId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public ShippingType ShippingType { get; private set; }
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.ToList();
    private List<OrderItem> _orderItems = new();

    private Order()
    {
        
    }

    public Order(int customerId,decimal totalAmount)
    {
        CustomerId = customerId;

        if(totalAmount<50000)
            throw new InvalidEntityStateException("ثبت سفارش با مبلغ کمتر از 50،000 تومان امکان پذیر نمی باشد.");

        if (DateTimeOffset.Now.Hour < 8 && DateTimeOffset.Now.Hour > 19)
            throw new InvalidEntityStateException("ثبت سفارش در این زمان مقدور نمی باشد.");

        AddEvent(new OrderCreated(BusinessId.Value, CustomerId,TotalAmount));
    }

    private Order(int customerId, List<OrderItem> items)
    {
        CustomerId = customerId;
       
        if (DateTimeOffset.Now.Hour < 8 && DateTimeOffset.Now.Hour > 19)
            throw new InvalidEntityStateException("ثبت سفارش در این زمان مقدور نمی باشد.");
        // Set order items
        _orderItems = items ?? new List<OrderItem>();
        // Calculate total amount
        TotalAmount = _orderItems.Sum(item => item.TotalPrice);
        if (items.Any(c => c.Product.ProductType == ProductType.FragileProduct))
        {
            ShippingType = ShippingType.Special;
        }
        else
        {
            ShippingType = ShippingType.Normal;
        }
        if (TotalAmount < 50000)
            throw new InvalidEntityStateException("ثبت سفارش با مبلغ کمتر از 50،000 تومان امکان پذیر نمی باشد.");

    }

    public static Order Create(int customerId, List<OrderItem> items)
    {
       
        // Additional business rules if needed


        // Create a new order with order items
        return new Order(customerId, items);
    }

    public void AddOrderItem(Product product, int quantity)
    {
        // Additional validation logic if needed
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        // Additional business rules if needed

        // Create a new order item and add it to the order
        var orderItem = new OrderItem(product, quantity);
        _orderItems.Add(orderItem);

        if (product.ProductType == ProductType.FragileProduct)
            ShippingType = ShippingType.Special;

        // Update the total amount of the order
        TotalAmount += orderItem.TotalPrice;
    }
}

public enum ShippingType
{
    Normal = 1,
    Special = 2

}