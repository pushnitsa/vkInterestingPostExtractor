using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace VkInterestingPostExtractor
{
    class Program
    {
        private static IConfiguration _configuration;
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            CreateConfiguration();
            CreateServiceProvider();

            _serviceProvider.GetService<VkMostInterestingPostFetcher>().Fetch();
        }

        private static void CreateConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, false)
                .Build();
        }

        private static void CreateServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddTransient<VkMostInterestingPostFetcher>()
                .AddVkApiFactory(_configuration)
                .AddSingleton<GroupInfoCollection>()
                .AddTransient<WallPostFetcher>()
                .AddTransient(s => new DateTimeOffsetFetcher(7))
                .AddTransient<GroupInfoResolver>()
                .AddTransmitters(_configuration)
                .AddCalculator()
                .BuildServiceProvider();
        }
    }
}
