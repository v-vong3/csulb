namespace patterns_demo.creational.builder.contract
{
    /// <summary>
    /// Defines a contract for a Task
    /// </summary>
    /// <remarks>
    /// Every Task inherits from ICommand giving it an Execute() behavior
    /// </remarks>
    public interface ITask : ICommand
    {
        // Allows for a linkage mechanism to another task similar to how a linked list behaves
        // This is useful when used in conjuction with the Builder pattern
        ITask NextTask {get; set;}
         
    }
}