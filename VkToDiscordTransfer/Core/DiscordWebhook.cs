using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace VkToDiscordTransfer.Core
{
    public class DiscordWebhook : IWebhook
    {
        private readonly string _url;
        private readonly string _username;

        public DiscordWebhook(string url, string username, string profilePicture)
        {
            _url = url;
            _username = username;
        }
        
        public void SendMessage(string messageTitle, string messageBody, string imageUrl)
        {
            var request = (HttpWebRequest) WebRequest.Create(_url);
            request.ContentType = "application/json";
            request.Method = "POST";
            
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(new
                {
                    username = _username,
                    embeds = new[]
                    {
                        new
                        {
                            description = messageBody,
                            title = messageTitle,
                            //color = "#6D02AB",
                            image = new
                            {
                                url = imageUrl
                            }
                        },
                    }
                });
                
                sw.Write(json);
                sw.Close();
            }

            request.GetResponse();
        }
        
    }
}