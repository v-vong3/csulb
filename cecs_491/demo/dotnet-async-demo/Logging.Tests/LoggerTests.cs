using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Logging.Tests
{
    [TestClass]
    public class LoggerTests
    {
        private readonly string _path;
        private readonly string _logFile;
        private readonly string _logFileExtension;
        private readonly string _logMessage;

        public LoggerTests()
        {
            _path = Directory.GetCurrentDirectory();
            _logFile = Path.Combine(_path, DateTime.Now.ToString("yyyyMMdd") + ".log");
            _logFileExtension = ".log";
            _logMessage = "{0} The quick brown fox jumps over the lazy dog\n";
        }

        [TestCleanup]
        public void DeleteLogFiles()
        {
            var logs = Directory.GetFiles(_path, "*" + _logFileExtension, SearchOption.TopDirectoryOnly);

            foreach (var log in logs)
            {
                // Changing the Solution Configuration to "Release" will enable the cleanup of log files
                // or putting a breakpoint on the line below will allow you to view log file before deletion

                File.Delete(log);

            }
        }


        [TestMethod]
        public void Sync_Log_SingleThread()
        {
            // Arrange
            var logger = new Logger(_path);
            var expected = true;

            // Act
            var actual = logger.Log(string.Format(_logMessage, "[Sync]"));

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(File.Exists(_logFile));
        }


        [TestMethod]
        public void Sync_Log_MultiThread()
        {
            // Arrange
            var logger = new Logger(_path);

            // Act
            for (var i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(x => logger.Log(string.Format(_logMessage, x)), i);
            }

            Thread.Sleep(120_000 / Environment.ProcessorCount); // Giving threads enough time to finish 100 writes

            /**** Notice that there are missing writes even when "extra" time is given  ****/

            // Assert
            Assert.IsTrue(File.Exists(_logFile));
        }

        [TestMethod]
        public async Task Async_Log_SingleThread()
        {
            // Arrange
            var logger = new AsyncLogger(_path);
            var expected = true;

            // Act
            var actual = await logger.LogAsync(string.Format(_logMessage, "[Async]"));

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(File.Exists(_logFile));
        }

        [TestMethod]
        public async Task AsyncV2_Log_SingleThread()
        {
            // Arrange
            var logger = new AsyncLoggerV2(_path);
            var expected = true;

            // Act
            var actual = await logger.LogAsync(string.Format(_logMessage, "[Async2]"));

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(File.Exists(_logFile));
        }


        [TestMethod]
        public async Task AsyncV3_Log_SingleThread()
        {
            // Arrange
            var logger = new AsyncLoggerV3(_path);
            var expected = new LogResponse()
            {
                IsSuccess = true
            };

            // Act
            var actual = await logger.LogAsync(string.Format(_logMessage, "[Async3]"));

            // Assert
            Assert.AreEqual(expected.IsSuccess, actual.IsSuccess);
            Assert.IsTrue(File.Exists(_logFile));
        }


        [TestMethod]
        public async Task AsyncV3_Log_MultiThread()
        {
            // Arrange
            var logger = new AsyncLoggerV3(_path);
            var expected = new LogResponse()
            {
                IsSuccess = true
            };

            // Act
            var tasks = Enumerable.Range(1, 100)
                                  .Select(x => logger.LogAsync(String.Format(_logMessage, $"[Async3 {x}]")));

            var actual = await Task.WhenAll(tasks.ToArray());

            /**** Notice no additional work is needed to schedule/coordinate all threads ****/


            // Assert
            Assert.IsTrue(actual.Length == 100); // Access to all 100 thread outcomes
            Assert.IsTrue(actual.All(a => a.IsSuccess)); // Checks that every task was successful
            Assert.IsTrue(File.Exists(_logFile));
        }

    }
}