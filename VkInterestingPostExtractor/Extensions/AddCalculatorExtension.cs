using VkInterestingPostExtractor.CalculationEngine;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddCalculatorExtension
    {
        public static IServiceCollection AddCalculator(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<ICalculator, Calculator>()
                .AddTransient<DataProcessor<IDataHandler>>()
                .AddTransient<IDataHandler, ViewsHandler>()
                .AddTransient<IDataHandler, RepostsHandler>()
                .AddTransient<IDataHandler, LikesHandler>();
        }
    }
}