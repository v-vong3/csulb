using System.Text;

namespace Logging
{
    public class AsyncLogger : IAsyncLogger
    {
        private readonly string _path;

        public AsyncLogger(string path)
        {
            _path = path;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        // Notice that the method definition does not have the "async" modifier
        public Task<bool> LogAsync(string message)
        {
            // Since an "await" is not used anywhere in the method, TaskCompletionSource<> is needed 
            // Notice that the TaskCreationOption is passed in to ensure that any Continuation to this method
            // is also capable of executing asynchronously
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            try
            {
                var filename = Path.Combine(_path, DateTime.Now.ToString("yyyyMMdd") + ".log");

                using (var fs = File.Open(filename, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write))
                {
                    var messageBytes = Encoding.UTF8.GetBytes(message);

                    fs.Write(messageBytes);
                    fs.Flush();
                }

                tcs.SetResult(true); // Can also use the TrySetResult() if you don't want failed sets to throw
            }
            catch (Exception ex)
            {
                tcs.SetException(ex); // Can also use the TrySetException() if you don't want failed sets to throw
            }

            return tcs.Task;  // Notice that we are returning a Task here instead of a simple boolean
        }

    }
}
