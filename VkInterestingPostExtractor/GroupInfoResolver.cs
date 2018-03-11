using System.Collections.Generic;
using System.Linq;
using VkInterestingPostExtractor.Transmitters;
using VkNet.Utils;

namespace VkInterestingPostExtractor
{
    class GroupInfoResolver
    {
        private readonly IGroupTransmitter _groupTransmitter;

        public GroupInfoResolver(IGroupTransmitter groupTransmitter)
        {
            _groupTransmitter = groupTransmitter;
        }

        public IReadOnlyList<GroupInfo> Resolve()
        {
            return _groupTransmitter.Get().Select(g => new GroupInfo
            {
                GroupId = g.Id,
                MembersCount = g.MembersCount ?? 0
            }).ToReadOnlyCollection();
        }
    }
}
