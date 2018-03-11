using VkNet;
using VkNet.Enums.Filters;

namespace VkInterestingPostExtractor
{
    class VkApiFactory
    {
        private readonly string _user;
        private readonly string _password;
        private readonly ulong _applicationId;
        private VkApi _vkApi;

        public VkApiFactory(string user, string password, ulong applicationId)
        {
            _user = user;
            _password = password;
            _applicationId = applicationId;
        }

        public VkApi Create()
        {
            _vkApi = new VkApi();

            Authorize();

            return _vkApi;
        }

        private void Authorize()
        {
            _vkApi.Authorize(new ApiAuthParams
            {
                ApplicationId = _applicationId,
                Login = _user,
                Password = _password,
                Settings = Settings.All
            });
        }
    }
}
