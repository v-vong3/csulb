
namespace ConsoleApp_Bootstrap
{
    /// <summary>
    /// Options Pattern implementation for <see cref="MyCustomApp" /> configurations
    /// <para>
    /// <remarks>
    /// Options classes must be non-abstract objects WITH a public parameterless constructor.
    /// Record types are better alternatives as they are meant for immutable data.
    /// </remarks>
    /// </para>
    /// </summary>
    public class MyCustomAppOptions
    {
        // DESIGN:
        // IServiceCollection.PostConfigure() doesn't allow overwriting the entire Option object's value,
        // so it is required that the UploadDate property is mutable to handle command-line overrides
        public string ArchivePath { get; set; } = string.Empty;

        public string ConnectionString { get; set; } = string.Empty;
    }
}

