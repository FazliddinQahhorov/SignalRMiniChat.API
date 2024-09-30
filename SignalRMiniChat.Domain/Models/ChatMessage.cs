namespace SignalRMiniChat.Domain.Models;

public class ChatMessage : Base
{
    public Guid UserId { get; set; } // Foydalanuvchi ID'si
    public Guid ChatId { get; set; } // Chat bilan bog'lanish uchun GUID formatidagi Id
    public Chat Chat { get; set; } // Navigation property
    public string Message { get; set; }
    public DateTime Timestamp { get; set; } // Xabar yuborilgan vaqti
}
