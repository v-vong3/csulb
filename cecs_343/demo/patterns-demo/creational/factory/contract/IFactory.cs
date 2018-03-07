namespace patterns_demo.creational.factoryMethod.contract
{
    /// <summary>
    /// Defines the interface for the Factory object
    /// </summary>
    public interface IFactory<T> where T : class // Using Generics to enforce return type of Create
    {
        // Some developers like to use CreateInstance instead of Create as the method name
        // Either works fine as long as the name of the implemented class object is descriptive
         T Create(string type);
    }
}