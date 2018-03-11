using System.Collections.Generic;
using System.Linq;
using VkNet.Utils;

namespace VkInterestingPostExtractor
{
    internal class GroupInfoCollection
    {
        private readonly GroupInfoResolver _resolver;
        private IReadOnlyList<GroupInfo> _groupInfoCollection;
        
        public GroupInfoCollection(GroupInfoResolver resolver)
        {
            _resolver = resolver;
        }

        public IReadOnlyCollection<long> GetGroupIds()
        {
            return GetGroupInfoCollection().Select(gi => gi.GroupId).ToReadOnlyCollection();
        }

        public IReadOnlyCollection<GroupInfo> GetGroupInfoCollection()
        {
            return _groupInfoCollection ?? (_groupInfoCollection = _resolver.Resolve());
        }
    }
}
