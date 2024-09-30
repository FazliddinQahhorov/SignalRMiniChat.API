using SignalRMiniChat.Application.DTO;
using SignalRMiniChat.Domain.Models;

namespace SignalRMiniChat.Application.Interfaces;

public interface IChatService
{
    Task<List<ChatForResult>> GetAllChatsAsync();
    Task<Chat> GetChatByIdAsync(Guid chatId);
    Task<Chat> CreateChatAsync(ChatForCreation chat, CancellationToken cancellationToken);
    Task<bool> EndChatAsync(Guid chatId);
    Task AddMessageAsync(ChatMessageForCreation message, CancellationToken cancellationToken);
}
