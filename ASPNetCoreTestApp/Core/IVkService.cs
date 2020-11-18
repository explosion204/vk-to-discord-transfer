using System;

namespace VkToDiscordTransfer.Core
{
    public interface IVkService
    {
        Tuple<string, string> GetLastPost(int ownerId);
    }
}