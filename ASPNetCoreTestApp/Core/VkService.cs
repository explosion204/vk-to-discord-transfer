using System;
using System.Linq;
using VkNet;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

namespace VkToDiscordTransfer.Core
{
    public class VkService : IVkService
    {
        private readonly VkApi _api;

        public VkService(VkApi api, string authToken)
        {
            _api = api;
            api.Authorize(new ApiAuthParams()
            {
                AccessToken = authToken
            });
        }
        
        public Tuple<string, string> GetLastPost(int ownerId)
        {
            var lastPost = _api.Wall.Get(new WallGetParams
            {
                OwnerId = -ownerId,
                Count = 1
            }).WallPosts.First();

            var imageUrl = string.Empty;
            
            foreach (var attachment in lastPost.Attachments)
            {
                if (attachment.Instance is Photo photo)
                {
                    imageUrl = photo.Sizes.Last().Url.ToString();
                    break;
                }
            }

            return Tuple.Create(lastPost.Text, imageUrl);
        }
    }
}