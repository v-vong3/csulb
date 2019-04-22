namespace abstraction_demo.After
{
    using System.Collections.Generic; // Importing namespace/library for List<>
    
    public class NameProcessor
    {
        // Private fields
        private List<IDataSource> _dataSources;
        private List<IFormat> _formats;
        private List<IDestination> _destinations;

        // Constructor for object
        public NameProcessor(List<IDataSrouce> dataSources, List<IFormat> formats, List<IDestination> destinations)
        {
            _dataSources = dataSources;
            _formats = formats;
            _destinations = destination;
        }

        public void Run()
        {
            // Step 1: Load data from all data sources by calling IDataSource.GetData()
            // Step 2: Apply format by calling IFormat.ApplyFormat()
            // Step 3: Send to destination by calling IDestination.Send() 
        }
    }
}