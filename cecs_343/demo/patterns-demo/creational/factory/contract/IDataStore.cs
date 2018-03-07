namespace patterns_demo.creational.factoryMethod.contract
{
    /// <summary>
    /// Contract for a Data Store
    /// </summary>
    public interface IDataStore
    {
        string Type {get;}
        
        bool Connect(object connection);

        bool Disconnect();

        object ExecuteCommand(object command, object[] parameters);

    }
}