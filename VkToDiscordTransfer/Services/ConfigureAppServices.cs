using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkToDiscordTransfer.Core;

namespace VkToDiscordTransfer.Services
{
    public class ConfigureAppServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IWebhook>(x => 
                new DiscordWebhook(
                    DiscordConfig.Url,
                    DiscordConfig.Username,
                    DiscordConfig.ProfilePicture));

            services.AddSingleton<IVkService>(x =>
                new VkService(new VkApi(), VkConfig.AuthToken));
        }
    }
}