namespace Logging
{
    public interface IAsyncLogger
    {
        // Returns a Task<bool> instead of a simple boolean to represent future work
        // "Async" suffix to denote that this operation is an asynchronous operation
        Task<bool> LogAsync(string message);
    }
}
