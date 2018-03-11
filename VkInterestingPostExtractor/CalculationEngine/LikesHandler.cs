using System.Collections.Generic;
using System.Linq;
using VkNet.Model;
using VkNet.Utils;

namespace VkInterestingPostExtractor.CalculationEngine
{
    public class LikesHandler : AbstractHandler
    {
        protected override IReadOnlyCollection<int> GetDataCollection(IReadOnlyCollection<Post> posts)
        {
            return posts.Select(p => p.Likes.Count).ToReadOnlyCollection();
        }
    }
}