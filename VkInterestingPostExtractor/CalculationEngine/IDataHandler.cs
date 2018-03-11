using System.Collections.Generic;
using VkNet.Model;

namespace VkInterestingPostExtractor.CalculationEngine
{
    public interface IDataHandler
    {
        int Handle(IReadOnlyCollection<Post> posts);
    }
}