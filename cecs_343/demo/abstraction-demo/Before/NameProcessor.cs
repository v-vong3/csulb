namespace abstraction_demo.Before
{
    using System.Collections.Generic; // For List<string> 

    public class NameProcessor
    {
        // Private data containers to hold data in memory
        private List<string> _namesFromCSV;
        private List<string> _namesFromWebService;

        private List<string> _namesForDatabase;
        private List<string> _namesForTextFile;

        public NameFormatter()
        {
            // Initializing data containers
            _namesFromCSV = new List<string>();
            _namesFromWebService = new List<string>();
            _namesForDatabase = new List<string>();
            _namesForTextFile = new List<string>();
        }

        /// <summary>
        /// Perform formatting of names to [LastName, Firstname]
        /// </summary>
        public void ConvertToLastNameFirstFormat()
        {
            // Step 1: For each name in _namesFromCSV, apply name format
            // Step 2: Insert formatted name into _namesForDatabase
            // Step 3: Insert formatted name into _namesForTextFile
            // Step 4: For each name in _namesFromWebService, apply name format
            // Step 5: Insert formatted name into _namesForDatabase
            // Step 6: Insert formatted name into _namesForTextFile
        }

        /// <summary>
        /// Retrieve data from a CSV file
        /// </summary>
        /// <param name="filePath">Fully qualified file name (FQFN)</param>
        public void GetNamesFromCSV(string filePath)
        {
            // Step 1: Check if file exist
            // Step 2: If file exist, read data line by line until end of file
            // Step 3: For each line read, insert into _namesFromCSV list
        }

        /// <summary>
        /// Retrieve names from a RESTful JSON web service
        /// </summary>
        /// <param name="webServiceUrl">Absolute URL endpoint of webservice</param>
        public void GetNamesFromWebService(string webServiceUrl)
        {
            // Step 1: Make HTTP GET request to webServiceUrl
            // Step 2: If HTTP request == 200 OK, deserialize JSON data in HTTP response body 
            // Step 3: For each element in the array, insert into _namesFromWebService  
        }

        /// <summary>
        /// Submit formatted names to a database 
        /// </summary>
        /// <param name="connectionString"></param>
        public void SaveNamesToDatabase(string connectionString)
        {
            // Step 1: Check if connection to database is valid
            // Step 2: If valid, open database connection
            // Step 3: For each name in _namesForDatabase, construct a corresponding SQL insert command
        }

        /// <summary>
        /// Save formatted names to a text file
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveNamesToTextFile(string filePath)
        {
            // Step 1: Check if file already exist
            // Step 2: If file exist, delete file
            // Step 3: Create file 
            // Step 4: For each name in _namesForTextFile, append name to new line
        }

    }
}