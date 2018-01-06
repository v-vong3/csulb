namespace abstraction_demo.After.DataSources
{
    public class JsonWebServiceDataSource : IDataSource
    {
        private string _webServiceUrl;
        private List<string> _data;

        // The constructor will enfoce any initialization required for this specific implementation of IDataSource
        public JsonWebServiceDataSource(string webServiceUrl)
        {
            _webServiceUrl = webServiceUrl;
            _data = new List<string>();
        }

        public List<string> Data => _data;
        
        public void GetData()
        {
            // Code to get data from web service and store it in _data
        }
    }
}