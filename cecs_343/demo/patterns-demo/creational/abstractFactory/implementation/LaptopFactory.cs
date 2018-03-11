using patterns_demo.creational.abstractFactory.contract;

namespace patterns_demo.creational.abstractFactory.implementation
{
    /// <summary>
    /// Concrete implementation of IComputerFactory
    /// Factory for building Laptops
    /// </summary>
    public class LaptopFactory : IComputerFactory
    {
        // Create an instance of a CPU
        public ICentralProcessingUnit CreateCPU()
        {
            throw new System.NotImplementedException();
        }

        // Create an instance of RAM
        public IRandomAccessMemory CreateRAM()
        {
            throw new System.NotImplementedException();
        }
    }
}