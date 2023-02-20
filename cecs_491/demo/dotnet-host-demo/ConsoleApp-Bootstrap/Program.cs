
using ConsoleApp_Bootstrap;

// Namespaces needed for leverage configuration file (JSON) to POCO mapping
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

// Only needed if you want command line overrides
using Microsoft.Extensions.Configuration.CommandLine;


// Namespace needed for .NET's built-in DI Container
using Microsoft.Extensions.DependencyInjection;

// Namespace needed for creating/running .NET "Hosts" and IHostedService interface
using Microsoft.Extensions.Hosting;



// dotnet bootstrapping of a "Host"
var hostBuilder = Host.CreateDefaultBuilder(args)

    .ConfigureAppConfiguration((hostingContext, cfgBuilder) =>
    {
        cfgBuilder.Sources.Clear(); // Clears all sources

        var configFilename = $"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json";

        cfgBuilder.AddJsonFile(configFilename);
        cfgBuilder.AddCommandLine(args);

    })

    .ConfigureServices((hostingContext, services) =>
    {
        services
            // Setup Configurations
            .Configure<AwsS3Options>(hostingContext.Configuration.GetSection(nameof(AwsS3Options)))
            .Configure<MyCustomAppOptions>(hostingContext.Configuration.GetSection(nameof(MyCustomAppOptions)))

            // Override Options with Command-Line values
            .PostConfigure<MyCustomAppOptions>((opts) =>
            {
                var configRoot = (IConfigurationRoot)hostingContext.Configuration;
                var provider = configRoot.Providers.First(p => p.GetType() == typeof(CommandLineConfigurationProvider));

                provider.TryGet(nameof(opts.ArchivePath), out var archivePath);

                // Setting the values from command-line
                opts.ArchivePath = archivePath;

            })


            // Setup Dependencies
            .AddTransient<IAwsS3Service>((services) =>
            {
                var opts = services.GetRequiredService<IOptions<AwsS3Options>>();

                // Example of providing configuration values to an object that you want registered with .NET's DI
                return new AwsS3Service(opts.Value.AccessKey, opts.Value.SecretKey);
            })

            // Application Bootstrapping
            .AddHostedService<MyCustomApp>();
    });

// .NET Core Quirk as of [2022-07]:
// Use the extension method RunConsoleAsync() to execute the "host" when leveraging async/await
// to ensure ConfigureAwait(false) is called properly by the "host"
//  https://source.dot.net/#Microsoft.Extensions.Hosting/HostingHostBuilderExtensions.cs,6754ed03a02b34d1
await hostBuilder.RunConsoleAsync();



