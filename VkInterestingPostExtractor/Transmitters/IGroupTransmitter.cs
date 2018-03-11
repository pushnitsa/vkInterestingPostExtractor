using System.Collections.Generic;
using VkNet.Model;

namespace VkInterestingPostExtractor.Transmitters
{
    internal interface IGroupTransmitter
    {
        IReadOnlyCollection<Group> Get();
    }
}