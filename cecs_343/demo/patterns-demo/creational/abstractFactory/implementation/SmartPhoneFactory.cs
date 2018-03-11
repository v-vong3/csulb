using patterns_demo.creational.abstractFactory.contract;

namespace patterns_demo.creational.abstractFactory.implementation
{
    /// <summary>
    /// Concrete implementation for IComputerFactory
    /// Factory for building Smart Phones
    /// </summary>
    public class SmartPhoneFactory : IComputerFactory
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