namespace SignalRMiniChat.Application.DTO;

public class ChatMessageDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
}
