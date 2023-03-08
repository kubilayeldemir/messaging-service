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
    public class MessageController : ControllerBase
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

            var isUserFound = await _messageService.SendMessageToUser(long.Parse(userId), model);
            if (!isUserFound)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMessageHistory([FromQuery] GetMessageHistoryRequestModel model)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
            var username = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "username")?.Value;
            if (userId == null || username == null)
            {
                return Unauthorized();
            }

            var messages =
                await _messageService.GetMessageHistoryWithPartner(username, long.Parse(userId), model.PartnerUsername);
            if (messages == null)
            {
                return NotFound();
            }
            return Ok(messages);
        }
    }
}