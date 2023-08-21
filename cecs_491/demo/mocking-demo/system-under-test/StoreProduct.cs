namespace mocking_demo;

public class StoreProduct : IEquatable<StoreProduct>
{
    public string Brand { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int AisleNumber { get; set; } 
    public bool IsOnSale { get; set; }


    

    // Implementation of interface IEquatable<StoreProduct>
    public bool Equals(StoreProduct? other)
    {
        if(other is null)
        {
            return false;
        }

        if(this.Brand == other.Brand
            && this.Name == other.Name 
            && this.Price == other.Price
            && this.AisleNumber == other.AisleNumber
            && this.IsOnSale == other.IsOnSale)
        {
            return true;
        }

        return false;
    }


    #region Additional required work for Equality implementation

    // .NET may invoke Equals() behind the scene in a lot of scenarios
    // so it is critical to also override Object.Equals() and Object.GetHashCode()
    public override bool Equals(object? obj)
    {
        return this.Equals(obj as StoreProduct);
    }

    public override int GetHashCode()
    {
        return this.Brand.GetHashCode() 
                ^ this.Name.GetHashCode() 
                ^ this.Price.GetHashCode()
                ^ this.AisleNumber.GetHashCode()
                ^ this.IsOnSale.GetHashCode();
    }

    // C# requires the following operators to be overloaded in pairs:
    // == and !=
    // < and >
    // <= and >=
    public static bool operator ==(StoreProduct left, StoreProduct right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(StoreProduct left, StoreProduct right)
    {
        return !left.Equals(right);
    }

    #endregion
}