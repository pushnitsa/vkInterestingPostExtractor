using System.Collections.Generic;
using VkNet.Model;

namespace VkInterestingPostExtractor.Transmitters
{
    internal interface IPostTransmitter
    {
        IReadOnlyCollection<Post> Get(long groupId, ulong offset);
    }
}