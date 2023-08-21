namespace mocking_demo;

using Moq;
using Xunit.Sdk;

public class MockingDemoTest
{

    [Fact]
    public void Store_NoMocking_Search()
    {
        // Arrange
        var inventoryService = new DatabaseInventoryService();
        var sut = new Store(inventoryService);
        var expected = new List<StoreProduct>()
        {
            new StoreProduct { Brand = "ABC", Name = "Desk", Price = 10.00M, AisleNumber = 1, IsOnSale = false  },
            new StoreProduct { Brand = "ACME", Name = "Desk", Price = 4.99M, AisleNumber = 100, IsOnSale = false },
            new StoreProduct { Brand = "XYZ", Name = "Desk", Price = 10.99M, AisleNumber = 1, IsOnSale = false  }
        };

        // Act
        var actual = sut.DisplayStoreProducts();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count == expected.Count);

        Assert.True(actual[0] == expected[0]);
        Assert.True(actual[1] == expected[1]);
        Assert.True(actual[2] == expected[2]);
    }


    [Fact]
    public void Store_MockingDependencyOut_Search()
    {
        // Arrange
        var expected = new List<StoreProduct>()
        {
            new StoreProduct { Brand = "ABC", Name = "Desk", Price = 10.00M, AisleNumber = 1, IsOnSale = false  },
            new StoreProduct { Brand = "XYZ", Name = "Desk", Price = 10.99M, AisleNumber = 1, IsOnSale = false  }
        };
        

        /** Start of Moq setup  **/
        var mockData = new List<Product>()
        {
            new Product { Brand = "ABC", Name = "Desk", Price = 10.00M },
            new Product { Brand = "XYZ", Name = "Desk", Price = 10.99M }
        };
        var mockService = new Mock<IInventoryService>();

        mockService.Setup(x => x.GetInventory()) // Selecting scenario to control
                   .Returns(mockData); // Setting behavior
        /** End of Moq setup **/

        var sut = new Store(mockService.Object); // Passing mock object as dependency to Store object
        

        // Act
        var actual = sut.DisplayStoreProducts();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count == expected.Count);

        foreach(var actualProduct in actual)
        {
            Assert.Contains(actualProduct, expected); // Better approach to asserting elements in collections
        }
    }

    [Fact]
    public void Service_OverridePropertyValue()
    {
        // Arrange
        var expected = 2;

        // Start of Moq setup
        var mockService = new Mock<IInventoryService>();
        mockService.SetupGet(x => x.MaxInventoryLimit)  // Moq can override property values as well
                   .Returns(expected);

        // Act
        var actual = mockService.Object.MaxInventoryLimit;

        // Assert
        Assert.True(actual == expected);
    }            

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    public void Store_SearchUsingRangeOfPriceValues(decimal price)
    {
        // Arrange

        /** Start of Moq setup  **/
        var mockData = new List<Product>()
        {
            new Product { Brand = "ABC", Name = "Desk", Price = 10.00M }
        };
        var mockData2 = new List<Product>()
        {
            new Product { Brand = "XYZ", Name = "Desk", Price = 10.99M }
        };
        var mockService = new Mock<IInventoryService>();

        mockService.Setup(x => x.SearchInventory(It.IsInRange<decimal>(1, 10, Range.Inclusive)))
                   .Returns(mockData); 

        mockService.Setup(x => x.SearchInventory(15))
                   .Returns(mockData2); 

        /** End of Moq setup **/

        var sut = new Store(mockService.Object); // Passing mock object as dependency to Store object
        

        // Act
        var actual = sut.Search(price);

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count == 1);
    }

/** Additional Moq methods 

    // Accepts any value of a data type
    Moq.Setup(x => x.SearchInventory(It.IsAny<decimal>()))
        .Returns(mockData2);

    // Another way to specify a range of data
    Moq.Setup(x => x.SearchInventory(It.Is<decimal>(d => d < 100)))
        .Returns(mockData2); 

    // Allow change tracking on specific property
    Moq.SetupProperty(x => x.MaxResultCount)
    
    // Allow change tracking on ALL properties
    Moq.SetupAllProperties(); // Call this before any other Moq.Setup() calls

**/

   
}