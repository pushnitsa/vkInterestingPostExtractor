using System;
using System.Collections.Generic;
using VkNet.Model;

namespace VkInterestingPostExtractor.CalculationEngine
{
    public class DataProcessor<T> where T : IDataHandler
    {
        private readonly T _handler;

        public DataProcessor(T handler)
        {
            _handler = handler;
        }
        
        public int Calculate(IReadOnlyCollection<Post> posts)
        {
            return _handler.Handle(posts);
        }
    }
}
