using Framework.Core.Domain.Entities;

namespace Charisma.Core.Domain.Products.Entities;

public class Product : AggregateRoot<int>
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public ProductType ProductType { get; private set; }


    public Product(string title, string description, decimal price, ProductType productType)
    {
        Title = title;
        Description = description;
        Price = price;
        ProductType = productType;
    }
}

public enum ProductType
{
    NormalProduct = 1,
    FragileProduct = 2

}


