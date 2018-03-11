namespace patterns_demo.creational.abstractFactory.contract
{
    /// <summary>
    /// Defines a contract for any computer factory
    /// </summary>
    public interface IComputerFactory
    {
        // Creates an instance of a CPU
        ICentralProcessingUnit CreateCPU();

        // Creates an instance of RAM
        IRandomAccessMemory CreateRAM();
    }
}