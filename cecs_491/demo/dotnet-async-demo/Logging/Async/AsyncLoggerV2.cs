using System.Text;

namespace Logging
{
    public class AsyncLoggerV2 : IAsyncLogger
    {
        private readonly string _path;

        public AsyncLoggerV2(string path)
        {
            _path = path;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        // Notice the "async" modifier is added here
        public async Task<bool> LogAsync(string message)
        {
            try
            {
                var filename = Path.Combine(_path, DateTime.Now.ToString("yyyyMMdd") + ".log");

                using (var fs = File.Open(filename, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write))
                {
                    var messageBytes = Encoding.UTF8.GetBytes(message);

                    // Notice the "await" is added here
                    await fs.WriteAsync(messageBytes).ConfigureAwait(false);

                    // Also notice the use of ConfigureAwait(false) whenever a method is awaited
                    await fs.FlushAsync().ConfigureAwait(false);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
