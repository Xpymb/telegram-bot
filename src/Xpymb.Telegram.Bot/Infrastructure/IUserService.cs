using Xpymb.Telegram.Bot.Infrastructure.Entities;

namespace Xpymb.Telegram.Bot.Infrastructure;

public interface IUserService
{
    Task<User?> GetAsync(long telegramId);
    IEnumerable<User?> GetAll();
    Task CreateAsync(UserCreate user);
}