namespace abstraction_demo.After.Formats
{
    /// <summary>
    /// Contract for applying a specific format
    /// </summary>
    public interface IFormat
    {
        string ApplyFormat(string data);
    }
}