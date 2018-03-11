using System.Collections.Generic;
using System.Linq;
using VkInterestingPostExtractor.CalculationEngine;
using VkNet.Model;

namespace VkInterestingPostExtractor
{
    public class PostHandler
    {
        private readonly ICalculator _calculator;
        private IReadOnlyCollection<Post> _postsCollection;
        
        public PostHandler(ICalculator calculator)
        {
            _calculator = calculator;
        }
        
        public void Handle(int membersCount, IReadOnlyCollection<Post> posts)
        {
            _postsCollection = posts;
            
            foreach (var post in _postsCollection)
            {
                var repostsCount = post.Reposts.Count;
                var likesCount = post.Likes.Count;
                var views = post.Views.Count;
            }
        }

        private void CalculateMedian()
        {
            var likesMedian = _calculator.GetLikesMedian(_postsCollection);
            var repostsMedian = _calculator.GetRepostsMedian(_postsCollection);
            var viewsMedian = _calculator.GetViewsMedian(_postsCollection);
        }
    }
}