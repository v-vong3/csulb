namespace patterns_demo.creational.factoryMethod.implementation
{
    using patterns_demo.creational.factoryMethod.contract;
    
    /// <summary>
    /// Concrete implementation of a Data Store Factory
    /// </summary>
    /// <remarks>
    /// Can also be implemented as a static class with a static Create method
    /// </remarks>
    public class DataStoreFactory : IDataStoreFactory
    {
        /// <summary>
        /// Creation of a new Data Store instance
        /// </summary>
        /// <param name="type">String literal of the type</param>
        /// <returns>A new instance of a Data Store</returns>
        public IDataStore Create(string type)
        {
            // Note 1: Use of the new keyword is isolated to this method only
            
            // Note 2: A string data type was used for type, but it could have been 
            // an Enumeration object as well
            switch(type?.ToUpper())
            {
                case DataStoreTypes.NoSql:
                    return new NoSqlDataStore();  

                case DataStoreTypes.File:
                    return new FileDataStore();

                // Case statement fall-through to account for default scenarios
                case DataStoreTypes.Default:
                case null:
                case "":
                default:
                    return new SqlDataStore();
            }
        }
    }
}