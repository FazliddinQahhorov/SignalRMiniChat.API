namespace SignalRMiniChat.Application.DTO;

public class ChatForResult
{
    public Guid Id { get; set; }
    public Guid AdminId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public bool IsActive { get; set; }
    public List<ChatMessageDTO> Messages { get; set; }
}
