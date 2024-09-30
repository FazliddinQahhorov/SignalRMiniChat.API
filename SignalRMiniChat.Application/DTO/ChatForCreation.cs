namespace SignalRMiniChat.Application.DTO;

public class ChatForCreation
{
    public Guid AdminId { get; set; } // Administrator/Operator ID
    public DateTime CreatedAt { get; set; } // Chat yaratilgan vaqti
    public DateTime? EndedAt { get; set; } // Chat tugatilgan vaqti (null bo'lishi mumkin)
    public bool IsActive { get; set; } // Chat hali davom etayotganligini ko'rsatadi
}
