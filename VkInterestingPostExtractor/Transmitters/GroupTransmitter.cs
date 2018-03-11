using System.Collections.Generic;
using System.Linq;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VkInterestingPostExtractor.Transmitters
{
    internal class GroupTransmitter : IGroupTransmitter
    {
        private readonly VkApiFactory _vkApiFactory;
        private readonly IReadOnlyCollection<string> _groupNames;
        
        public GroupTransmitter(
            VkApiFactory vkApiFactory,
            IReadOnlyCollection<string> groupNames
            )
        {
            _vkApiFactory = vkApiFactory;
            _groupNames = groupNames;
        }
        
        public IReadOnlyCollection<Group> Get()
        {
            using (var vkApi = _vkApiFactory.Create())
            {
                return vkApi
                    .Groups
                    .GetById(_groupNames, "", GroupsFields.MembersCount);
            }
        }
    }
}