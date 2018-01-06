namespace abstraction_demo.After.DataSources
{
    using System.Collections.Generic; // Importing namespace/library for List<>

    public class CsvDataSource : IDataSource
    {
        private string _filePath;
        private List<string> _data;

        // The constructor will enfoce any initialization required for this specific implementation of IDataSource
        public CsvDataSource(string filePath)
        {
            _filePath = filePath;
            _data = new List<string>();
        }

        public List<string> Data => _data;

        public void GetData()
        {
            // Code to get data from a CSV file and store it in Data
        }

    }
}