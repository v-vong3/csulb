using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace mocking_demo;

public class Store
{
    private readonly IInventoryService _inventoryService;

    public Store(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }


    private int AssignAisleNumber(Product product)
    {
        if(product.Price >= 10.00M)
        {
            return 1;
        }

        return 100;
    }


    public IList<StoreProduct> DisplayStoreProducts()
    {
        var products = _inventoryService.GetInventory()
                                        .Select(p => new StoreProduct() 
                                        {
                                            Brand = p.Brand,
                                            Name = p.Name,
                                            Price = p.Price,
                                            AisleNumber = AssignAisleNumber(p),
                                            IsOnSale = false
                                        })
                                        .ToList();

        return products;
    }

    public IList<StoreProduct> Search(decimal maxPrice)
    {
        var searchResults = _inventoryService.SearchInventory(maxPrice) 
                                             .Select(p => new StoreProduct() 
                                             {
                                                Brand = p.Brand,
                                                Name = p.Name,
                                                Price = p.Price,
                                                AisleNumber = AssignAisleNumber(p),
                                                IsOnSale = false
                                             })
                                             .ToList();
        return searchResults;
    }


    public IList<StoreProduct> Search(string brand)
    {
        var searchResults = _inventoryService.SearchInventory(brand) 
                                             .Select(p => new StoreProduct() 
                                             {
                                                Brand = p.Brand,
                                                Name = p.Name,
                                                Price = p.Price,
                                                AisleNumber = AssignAisleNumber(p),
                                                IsOnSale = false
                                             })
                                             .ToList();
        return searchResults;
    }
}
