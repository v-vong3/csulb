namespace mocking_demo;

public class Product
{
    public Product() {}

    public Product(string brand, string name, decimal price)
    {
        Brand = brand;
        Name = name;
        Price = price;
    }


    public string Brand { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }


}