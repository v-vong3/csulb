namespace patterns_demo.creational.factoryMethod.contract
{
    /// <summary>
    /// Specific contract for a Data Store Factory
    /// </summary>
    public interface IDataStoreFactory : IFactory<IDataStore>
    {
        // Now I don't have to explicitly specify IDataStore in any concrete implementation
        // of this interface.  Also, IFactory can be used with other data types and for other
        // scenarios
    }
}