using System.Text;

namespace Logging
{
    public class Logger : ILogger
    {
        private readonly string _path;

        public Logger(string path)
        {
            _path = path;

            // Always a good idea to ensure IO is set properly before use
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public bool Log(string message)
        {
            try
            {
                // Creates fully-qualified filename
                var filename = Path.Combine(_path, DateTime.Now.ToString("yyyyMMdd") + ".log");

                // Using a using statement to ensure FileStream object "fs" is automatically closed once done writing
                using (var fs = File.Open(filename, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write))
                {
                    // Encoding determines how to interpret what the bytes means, thus it is necessary for any textual data
                    var messageBytes = Encoding.UTF8.GetBytes(message);

                    fs.Write(messageBytes);
                    fs.Flush(); // Technically not needed, but used to show a point in async examples
                }

                return true;
            }
            catch (IOException)
            {
                // Caller only knows that operation failed but doesn't know what caused the failure
                return false;
            }

        }

    }
}