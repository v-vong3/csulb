namespace abstraction_demo.After.Destinations
{
     using System.Collections.Generic; // Importing namespace/library for List<>

    public class DatabaseDestination : IDestination
    {

        private string _connString;


        public DatabaseDestination(string connectionString)
        {
            _connString = connectionString;
        }

        public void Send(List<string> data)
        {
            // Code to send data to database table
        }   
    }
}