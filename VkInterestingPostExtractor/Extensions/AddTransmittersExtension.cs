using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using VkInterestingPostExtractor;
using VkInterestingPostExtractor.Transmitters;

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class AddTransmittersExtension
    {
        public static IServiceCollection AddTransmitters(
            this IServiceCollection serviceCollection, 
            IConfiguration configuration
            )
        {
            var groupNames = new List<string>();
            configuration.Bind("GroupNames", groupNames);
            
            return serviceCollection
                .AddTransient<IPostTransmitter, PostTransmitter>()
                .AddTransient<IGroupTransmitter>(s => 
                    new GroupTransmitter(
                        s.GetService<VkApiFactory>(),
                        groupNames
                    )
                );
        }
    }
}