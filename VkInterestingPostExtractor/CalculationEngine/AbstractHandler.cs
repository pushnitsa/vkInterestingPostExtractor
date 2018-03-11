using System;
using System.Collections.Generic;
using System.Linq;
using VkNet.Model;

namespace VkInterestingPostExtractor.CalculationEngine
{
    public abstract class AbstractHandler : IDataHandler
    {
        protected abstract IReadOnlyCollection<int> GetDataCollection(IReadOnlyCollection<Post> posts);

        public int Handle(IReadOnlyCollection<Post> posts)
        {
            var sourceData = GetDataCollection(posts);

            var sumSourceData = sourceData.Sum();
            var countSourceData = sourceData.Count();

            return sumSourceData / countSourceData;
        }
    }
}