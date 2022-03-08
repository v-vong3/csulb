namespace Logging
{
    /// <summary>
    /// An abstraction for the response of any log operation
    /// </summary>
    public class LogResponse
    {
        /// <summary>
        /// Detailed error message; will be null if <see cref="IsSuccess" /> is true
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// Flag for successful operation
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Source of operation failure
        /// </summary>
        public RootCause FailureSource { get; set; }

    }

    /// <summary>
    /// Categories of failure
    /// </summary>
    public enum RootCause
    {
        Unknown,
        IO,
        Permission,
        Timeout,
        FunctionalReq,
        NonFunctionalReq
    }

}
