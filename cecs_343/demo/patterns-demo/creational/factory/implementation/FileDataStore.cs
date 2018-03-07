using patterns_demo.creational.factoryMethod.contract;

namespace patterns_demo.creational.factoryMethod.implementation
{
    public class FileDataStore : IDataStore
    {
        public string Type => DataStoreTypes.File;

        public bool Connect(object connection)
        {
            throw new System.NotImplementedException();
        }

        public bool Disconnect()
        {
            throw new System.NotImplementedException();
        }

        public object ExecuteCommand(object command, object[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}