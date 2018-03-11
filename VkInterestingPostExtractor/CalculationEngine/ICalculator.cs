using System.Collections.Generic;
using VkNet.Model;

namespace VkInterestingPostExtractor.CalculationEngine
{
    public interface ICalculator
    {
        int GetViewsMedian(IReadOnlyCollection<Post> posts);

        int GetRepostsMedian(IReadOnlyCollection<Post> posts);

        int GetLikesMedian(IReadOnlyCollection<Post> posts);
    }
}