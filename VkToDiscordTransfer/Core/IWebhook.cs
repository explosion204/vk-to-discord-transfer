namespace VkToDiscordTransfer.Core
{
    public interface IWebhook
    {
        void SendMessage(string messageTitle, string messageBody, string imageUrl);
    }
}