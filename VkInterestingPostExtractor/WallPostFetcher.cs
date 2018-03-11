using System.Collections.Generic;
using System.Linq;
using VkInterestingPostExtractor.Exceptions;
using VkInterestingPostExtractor.Transmitters;
using VkNet.Model;
using VkNet.Utils;

namespace VkInterestingPostExtractor
{
    class WallPostFetcher
    {
        private List<Post> _wallPostCollection = new List<Post>();
        private readonly DateTimeOffsetFetcher _dateTimeOffsetFetcher;
        private ulong _entriesOffset = 0;
        private readonly IPostTransmitter _postTransmitter;

        public WallPostFetcher(
            DateTimeOffsetFetcher dateTimeOffsetFetcher,
            IPostTransmitter postTransmitter
            )
        {
            _dateTimeOffsetFetcher = dateTimeOffsetFetcher;
            _postTransmitter = postTransmitter;
        }

        public IReadOnlyCollection<Post> FetchPosts(long groupId)
        {
            var dateTimeOffset = _dateTimeOffsetFetcher.GetDateTime();
            
            GetPosts(groupId);
            
            CutOldPosts();

            return _wallPostCollection.ToReadOnlyCollection();
        }

        private void GetPosts(long groupId)
        {
            var posts = _postTransmitter.Get(groupId, _entriesOffset);
            _wallPostCollection.AddRange(posts);

            if (false == IsEnough())
            {
                _entriesOffset = _entriesOffset + 100;
                GetPosts(groupId);
            }
        }

        private bool IsEnough()
        {
            var lastLoadedPost = _wallPostCollection.Last();

            if (lastLoadedPost.Date == null)
            {
                throw new DateTimeNullException();
            }

            return lastLoadedPost.Date <= _dateTimeOffsetFetcher.GetDateTime();
        }

        private void CutOldPosts()
        {
            _wallPostCollection = _wallPostCollection
                .OrderBy(p => p.Date)
                .ToList();

            var postsToRemoving = new List<int>();

            for (var i = 0; i < _wallPostCollection.Count; i++)
            {
                if (_wallPostCollection[i].Date < _dateTimeOffsetFetcher.GetDateTime())
                {
                    postsToRemoving.Add(i);
                }
                else
                {
                    _wallPostCollection.RemoveRange(0, postsToRemoving.Count);
                    break;
                }
            }
        }
    }
}
