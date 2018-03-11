using Microsoft.Extensions.Configuration;
using VkInterestingPostExtractor;

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class AddVkApiFactoryExtension
    {
        public static IServiceCollection AddVkApiFactory(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            return serviceCollection
                .AddTransient(s => new VkApiFactory(
                    user: configuration.GetValue<string>("User"),
                    password: configuration.GetValue<string>("Password"),
                    applicationId: configuration.GetValue<ulong>("ApplicationId")
                ));
        }
    }
}
