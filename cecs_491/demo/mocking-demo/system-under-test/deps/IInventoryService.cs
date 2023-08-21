namespace mocking_demo;

public interface IInventoryService
{
    IList<Product> GetInventory();

    IList<Product> SearchInventory(string brand);

    IList<Product> SearchInventory(decimal maxPrice);

    int MaxInventoryLimit { get; set; }
}
