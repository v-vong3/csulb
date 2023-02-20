namespace ConsoleApp_Bootstrap
{
    /// <summary>
    /// Options Pattern implementation for <see cref="AwsS3Service" /> configurations
    /// <para>
    /// <remarks>
    /// Options classes must be non-abstract objects WITH a public parameterless constructor.
    /// Record types are better alternatives as they are meant for immutable data.
    /// </remarks>
    /// </para>
    /// </summary>
    internal record AwsS3Options
    {
        public string AccessKey { get; init; } = string.Empty;
        public string SecretKey { get; init; } = string.Empty;
        public string RootBucketName { get; init; } = string.Empty;
    }
}