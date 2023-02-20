
namespace ConsoleApp_Bootstrap
{
    internal class AwsS3Service : IAwsS3Service
    {
        private readonly string _accessKey;
        private readonly string _secretKey;


        // .NET's DI will provide the actual arguments for the constructor
        public AwsS3Service(string accessKey, string secretKey)
        {
            _accessKey = accessKey;
            _secretKey = secretKey;
        }

        public void SendToS3()
        {
            // NOOP
        }

    }
}

