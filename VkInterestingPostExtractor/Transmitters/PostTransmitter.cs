using System.Collections.Generic;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkInterestingPostExtractor.Transmitters
{
    internal class PostTransmitter : IPostTransmitter
    {
        private readonly VkApiFactory _vkApiFactory;
        
        public PostTransmitter(VkApiFactory apiFactory)
        {
            _vkApiFactory = apiFactory;
        }
        
        public IReadOnlyCollection<Post> Get(long groupId, ulong offset)
        {
            using (var vkApi = _vkApiFactory.Create())
            {
                var res = vkApi.Wall.Get(new WallGetParams
                {
                    OwnerId = -groupId,
                    Offset = offset,
                    Count = 100
                });

                return res.WallPosts;
            }
        }
    }
}