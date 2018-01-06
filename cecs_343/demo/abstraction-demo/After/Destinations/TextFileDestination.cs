namespace abstraction_demo.After.Destinations
{
    using System.Collections.Generic; // Importing namespace/library for List<>

    public class TextFileDestination : IDestination
    {
        private string _filePath;

        public TextFileDestination(string filePath)
        {
            _filePath = filePath;
        }

        public void Send(List<string> data)
        {
            // Code to send data text file
        }
    }
}