namespace abstraction_demo.After.Destinations
{
    using System.Collections.Generic; // Importing namespace/library for List<>

    /// <summary>
    /// Contract for sending data to a destination
    /// </summary>
    public interface IDestination
    {
         void Send(List<string> data);
    }
}