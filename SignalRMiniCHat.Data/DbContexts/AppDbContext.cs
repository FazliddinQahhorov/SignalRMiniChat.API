using Microsoft.EntityFrameworkCore;
using SignalRMiniChat.Domain.Models;

namespace SignalRMiniCHat.Data.AppDbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //Database.Migrate();
    }

    #region
    DbSet<Admin> admins;
    DbSet<Chat> chats;
    DbSet<User> users;
    DbSet<ChatMessage> messages;
    #endregion
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Admin va Chat o'rtasidagi bir-Admin va bir-necha-Chat bog'lanishi
        modelBuilder.Entity<Chat>()
            .HasOne<Admin>() // Chat har doim bitta Adminga tegishli
            .WithMany() // Admin bir nechta Chatga ega bo'lishi mumkin
            .HasForeignKey(c => c.AdminId) // AdminId foreign key sifatida ishlatiladi
            .OnDelete(DeleteBehavior.Restrict); // Admin o'chirilsa, chatlar o'chirilmaydi

        // User va ChatMessage o'rtasidagi bir-User va bir-necha-ChatMessage bog'lanishi
        modelBuilder.Entity<ChatMessage>()
            .HasOne<User>() // ChatMessage har doim bitta User tomonidan yuboriladi
            .WithMany() // User bir nechta ChatMessage yuborishi mumkin
            .HasForeignKey(cm => cm.UserId) // UserId foreign key sifatida ishlatiladi
            .OnDelete(DeleteBehavior.Restrict); // User o'chirilsa, ChatMessages o'chirilmaydi

        // Chat va ChatMessage o'rtasidagi bir-Chat va bir-necha-ChatMessage bog'lanishi
        modelBuilder.Entity<ChatMessage>()
            .HasOne(cm => cm.Chat) // ChatMessage bir Chatga tegishli
            .WithMany(c => c.Messages) // Chatda bir nechta ChatMessage bo'ladi
            .HasForeignKey(cm => cm.ChatId) // ChatId foreign key sifatida ishlatiladi
            .OnDelete(DeleteBehavior.Cascade); // Chat o'chirilsa, unga tegishli barcha xabarlar ham o'chiriladi
    }
}
