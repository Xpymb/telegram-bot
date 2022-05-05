namespace Xpymb.Telegram.Bot.Data.Entities;

public interface IEntity
{
    Guid Id { get; set; }
    bool IsActive { get; set; }
    DateTime DateCreated { get; set; }
    DateTime? DateUpdated { get; set; }
}