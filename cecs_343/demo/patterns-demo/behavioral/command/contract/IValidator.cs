namespace patterns_demo.behavioral.command.contract
{
    /// <summary>
    /// Defines contract for Validate command
    /// </summary>
    public interface IValidator
    {
        // Not using System.Generics in order to show manual type casting
        // Typically a command is implemented without any arguments and often times with a void return type
        bool Validate(object entity); 
    }
}