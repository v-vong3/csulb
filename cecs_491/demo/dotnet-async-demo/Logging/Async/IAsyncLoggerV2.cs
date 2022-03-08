namespace Logging
{
    public interface IAsyncLoggerV2
    {
        // Returns a Task<LogResponse> instead of a Task<bool> 
        // LogResponse provides the caller with additional information for scenario evaluation 
        Task<LogResponse> LogAsync(string message);
    }
}
