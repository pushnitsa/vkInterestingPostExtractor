using System.Collections.Generic;
using VkNet.Model;

namespace VkInterestingPostExtractor.CalculationEngine
{
    public class Calculator : ICalculator
    {
        private readonly DataProcessor<ViewsHandler> _viewsProcessor;
        private readonly DataProcessor<LikesHandler> _likesProcessor;
        private readonly DataProcessor<RepostsHandler> _repostsProcessor;
        
        public Calculator(
            DataProcessor<ViewsHandler> viewsProcessor,
            DataProcessor<LikesHandler> likesProcessor,
            DataProcessor<RepostsHandler> repostsProcessor
            )
        {
            _viewsProcessor = viewsProcessor;
            _likesProcessor = likesProcessor;
            _repostsProcessor = repostsProcessor;
        }

        public int GetViewsMedian(IReadOnlyCollection<Post> posts)
        {
            return _viewsProcessor.Calculate(posts);
        }

        public int GetRepostsMedian(IReadOnlyCollection<Post> posts)
        {
            return _repostsProcessor.Calculate(posts);
        }

        public int GetLikesMedian(IReadOnlyCollection<Post> posts)
        {
            return _likesProcessor.Calculate(posts);
        }
    }
}