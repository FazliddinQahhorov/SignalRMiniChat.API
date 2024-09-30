namespace SignalRMiniChat.Application.DTO;

public class ChatMessageForCreation
{
    public Guid UserId { get; set; } // Foydalanuvchi ID'si
    public Guid ChatId { get; set; } // Chat bilan bog'lanish uchun GUID formatidagi Id
    public string Message { get; set; }
    public DateTime Timestamp { get; set; } // Xabar yuborilgan vaqti
}
