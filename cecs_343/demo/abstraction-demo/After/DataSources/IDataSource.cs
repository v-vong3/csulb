namespace abstraction_demo.After.DataSources
{
    using System.Collections.Generic; // Importing namespace/library for List<>

    /// <summary>
    /// Contract for retrieving data from a source
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Retrieve the data
        /// </summary>
        void GetData();

        /// <summary>
        /// View that data that we retrieve
        /// </summary>
        /// <returns>A collection of strings</returns>
        List<string> Data {get;}
    }
}