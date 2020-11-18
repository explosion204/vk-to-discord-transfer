using System;
using Microsoft.AspNetCore.Mvc;
using VkToDiscordTransfer.Core;
using VkToDiscordTransfer.Models;
using VkToDiscordTransfer.Services;

namespace VkToDiscordTransfer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscordController : Controller
    {
        private readonly IWebhook _webhook;
        private readonly IVkService _vkService;
        
        public DiscordController(IWebhook webhook, IVkService vkService)
        {
            _webhook = webhook;
            _vkService = vkService;
        }
        
        [HttpGet]
        public string Get() => "test ok";
        
        [HttpPost]
        [Route("vk_callback")]
        public IActionResult Post([FromBody] Request request)
        {
            switch (request.Type)
            {
                case "wall_post_new":
                    var (messageBody, imageUrl) = _vkService.GetLastPost(request.GroupId);
                    var messageTitle = AppConfig.MessageTitle;
                    _webhook.SendMessage(messageTitle, messageBody, imageUrl);
                    
                    return Ok("ok");
                
                case "confirmation":
                    return Ok(VkConfig.ServerValidationString);
                
                default:
                    return Ok();
            }
        }
    }
}