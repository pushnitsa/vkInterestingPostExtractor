using System.Collections.Generic;
using VkNet.Model;

namespace VkInterestingPostExtractor
{
    class VkMostInterestingPostFetcher
    {
        private readonly GroupInfoCollection _groupInfoCollection;
        private readonly WallPostFetcher _wallPostFetcher;

        public VkMostInterestingPostFetcher(
            GroupInfoCollection groupInfoCollection,
            WallPostFetcher wallPostFetcher
            )
        {
            _groupInfoCollection = groupInfoCollection;
            _wallPostFetcher = wallPostFetcher;
        }

        public void Fetch()
        {
            var groupIds = _groupInfoCollection.GetGroupIds();

            foreach (var groupId in groupIds)
            {
                var posts = _wallPostFetcher.FetchPosts(groupId);
            }
        }
    }
}
