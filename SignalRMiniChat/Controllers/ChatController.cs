using Microsoft.AspNetCore.Mvc;
using SignalRMiniChat.Application.DTO;
using SignalRMiniChat.Application.Interfaces;
using SignalRMiniChat.Domain.Models;

namespace SignalRMiniChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Chat>>> GetAllChatsAsync()
        {
            var chats = await _chatService.GetAllChatsAsync();
            return Ok(chats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatByIdAsync(Guid id)
        {
            var chat = await _chatService.GetChatByIdAsync(id);
            if (chat == null)
            {
                return NotFound();
            }
            return Ok(chat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChatAsync([FromBody] ChatForCreation chat, CancellationToken cancellationToken)
        {
            var createdChat = await _chatService.CreateChatAsync(chat, cancellationToken);
            return Ok(createdChat);
        }

        [HttpPut("{id}/end")]
        public async Task<IActionResult> EndChatAsync(Guid id)
        {
            var success = await _chatService.EndChatAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok(success);
        }

        [HttpPost("message")]
        public async Task<IActionResult> AddMessageAsync([FromBody] ChatMessageForCreation message, CancellationToken cancellationToken)
        {
            await _chatService.AddMessageAsync(message, cancellationToken);
            return Ok();
        }
    }
}
