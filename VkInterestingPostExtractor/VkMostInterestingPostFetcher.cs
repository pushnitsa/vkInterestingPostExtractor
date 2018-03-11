using System.Collections.Generic;
using VkNet.Model;

namespace VkInterestingPostExtractor
{
    class VkMostInterestingPostFetcher
    {
        private readonly GroupInfoCollection _groupInfoCollection;
        private readonly WallPostFetcher _wallPostFetcher;
        private readonly PostHandler _postHandler;

        public VkMostInterestingPostFetcher(
            GroupInfoCollection groupInfoCollection,
            WallPostFetcher wallPostFetcher,
            PostHandler postHandler
            )
        {
            _groupInfoCollection = groupInfoCollection;
            _wallPostFetcher = wallPostFetcher;
            _postHandler = postHandler;
        }

        public void Fetch()
        {
            var groupIfoCollection = _groupInfoCollection.GetGroupInfoCollection();

            foreach (var groupInfo in groupIfoCollection)
            {
                var posts = _wallPostFetcher.FetchPosts(groupInfo.GroupId);
                _postHandler.Handle(groupInfo.MembersCount, posts);
            }
        }
    }
}
