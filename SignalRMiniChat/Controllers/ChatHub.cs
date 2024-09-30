using global::SignalRMiniChat.Application.Interfaces;
using global::SignalRMiniChat.Domain.Models;
using Microsoft.AspNetCore.SignalR;
using SignalRMiniChat.Application.DTO;


namespace SignalRMiniChat.Controllers
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(Guid chatId, string userId, string messageContent, CancellationToken cancellationToken)
        {
            var message = new ChatMessageForCreation
            {
                ChatId = chatId,
                UserId = Guid.Parse(userId),
                Message = messageContent,
                Timestamp = DateTime.UtcNow
            };

            await _chatService.AddMessageAsync(message, cancellationToken);

            // Clientlarga xabar yuborish
            await Clients.Group(chatId.ToString()).SendAsync("ReceiveMessage", message);
        }

        public async Task JoinChat(Guid chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        }

        public async Task LeaveChat(Guid chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
        }
    }


}
