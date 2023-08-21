namespace mocking_demo;

public class DatabaseInventoryService : IInventoryService
{
    public IList<Product> GetInventory()
    {
        var inventory = new List<Product>();

        /** Open connection to Database code **/

        // Assume that the inventory is populated by records found in database
        inventory.Add(new Product("ABC", "Desk", 10.00M));
        inventory.Add(new Product("ACME", "Desk", 4.99M));
        inventory.Add(new Product("XYZ", "Desk", 10.99M));

        /** Terminate connection to Database code **/

        return inventory;
    }

    public IList<Product> SearchInventory(string brand)
    {
        var inventory = GetInventory();

        // For production-ready code, filtering should occur at the database end to minimize app server resource usage
        var filteredResults = inventory.Where(p => p.Brand.Equals(brand, StringComparison.CurrentCultureIgnoreCase))
                                       .ToList();

        return filteredResults;
    }


    public IList<Product> SearchInventory(decimal maxPrice)
    {
        var inventory = GetInventory();

        // For production-ready code, filtering should occur at the database end to minimize app server resource usage
        var filteredResults = inventory.Where(p => p.Price <= maxPrice)
                                       .ToList();

        return filteredResults;
    }

    public int MaxInventoryLimit { get; set; } = 100;  // Default value of 100
}
