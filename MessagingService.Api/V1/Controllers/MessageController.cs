using System.Linq;
using System.Threading.Tasks;
using MessagingService.Api.Services;
using MessagingService.Api.V1.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessagingService.Api.V1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MessageController  : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SendMessageToUser([FromBody] SendMessageRequest model)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }
            await _messageService.SendMessageToUser(long.Parse(userId), model);
            return Ok();
        }
    }
}