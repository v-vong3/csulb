using System.Security;
using System.Text;

namespace Logging
{
    public class AsyncLoggerV3 : IAsyncLoggerV2
    {
        private static readonly SemaphoreSlim _semaphoreSlim = new(1, 1);
        private readonly string _path;

        public AsyncLoggerV3(string path)
        {
            _path = path;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


        // Placeholder for authorization check
        private void CheckPermissions()
        {
            if (false) // Check for permission here
            {
                throw new SecurityException("User not allowed to log");
            }
        }


        public async Task<LogResponse> LogAsync(string message)
        {
            var response = new LogResponse();
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            await _semaphoreSlim.WaitAsync();
            try
            {
                CheckPermissions();

                var filename = Path.Combine(_path, DateTime.Now.ToString("yyyyMMdd") + ".log");

                using (var fs = File.Open(filename, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write))
                {
                    var messageBytes = Encoding.UTF8.GetBytes(message);

                    await fs.WriteAsync(messageBytes, cts.Token).ConfigureAwait(false);

                    await fs.FlushAsync().ConfigureAwait(false);
                }


                response.IsSuccess = true;
            }
            catch (TaskCanceledException tcex)
            {
                // Caller has enough information to evaluate this error as a potential retryable scenario
                response.FailureSource = RootCause.NonFunctionalReq;
                response.Error = tcex.Message;
            }
            catch (SecurityException se)
            {
                // Caller has enough infomration to evaluate this error as a non-retryable scenario
                response.FailureSource = RootCause.Permission;
                response.Error = se.Message;
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
            }
            finally
            {
                _semaphoreSlim.Release();
            }

            return response;
        }
    }
}
