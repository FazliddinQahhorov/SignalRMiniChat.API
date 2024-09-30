using AutoMapper;
using SignalRMiniChat.Application.DTO;
using SignalRMiniChat.Application.Interfaces;
using SignalRMiniChat.Domain.Models;
using SignalRMiniCHat.Data.Interfaces;

namespace SignalRMiniChat.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IGenericRepository<Chat> _chatRepository;
        private readonly IGenericRepository<ChatMessage> _messageRepository;
        private readonly IMapper mapper;

        public ChatService(
            IGenericRepository<Chat> chatRepository,
            IGenericRepository<ChatMessage> messageRepository,
            IMapper mapper)
        {
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
            this.mapper = mapper;
        }

        public async Task<List<ChatForResult>> GetAllChatsAsync()
        {
            var chats = _chatRepository.GetAll(c => c.Messages).ToList();
            return mapper.Map<List<ChatForResult>>(chats);
        }

        public async Task<Chat> GetChatByIdAsync(Guid chatId)
        {
            return await _chatRepository.GetAsync(u => u.Id == chatId);
        }

        public async Task<Chat> CreateChatAsync(ChatForCreation chat, CancellationToken cancellationToken)
        {
            var result = await _chatRepository.CreateAsync(mapper.Map<Chat>(chat));
            await _chatRepository.SavesChangesAsync(cancellationToken);
            return result;
        }

        public async Task<bool> EndChatAsync(Guid chatId)
        {
            var chat = await _chatRepository.GetAsync(u => u.Id == chatId);
            if (chat == null) return false;

            chat.IsActive = false;
            chat.EndedAt = DateTime.UtcNow;

            await _chatRepository.UpdateAsync(chat);
            return true;
        }

        public async Task AddMessageAsync(ChatMessageForCreation message, CancellationToken cancellationToken)
        {
            await _messageRepository.CreateAsync(mapper.Map<ChatMessage>(message));
            await _chatRepository.SavesChangesAsync(cancellationToken);
        }
    }
}
