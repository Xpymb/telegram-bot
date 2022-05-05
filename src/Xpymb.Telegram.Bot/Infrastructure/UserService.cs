using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xpymb.Telegram.Bot.Data;
using Xpymb.Telegram.Bot.Data.Entities;
using Xpymb.Telegram.Bot.Infrastructure.Entities;

namespace Xpymb.Telegram.Bot.Infrastructure;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserService(
        ApplicationDbContext _dbContext,
        IMapper mapper)
    {
        this._dbContext = _dbContext;
        _mapper = mapper;
    }
    
    public async Task<User?> GetAsync(long telegramId)
    {
        var entity = await _dbContext.Set<UserEntity>().Where(x => x.TelegramId == telegramId).FirstOrDefaultAsync();

        var result = _mapper.Map<User>(entity);
        return entity is not null ? result : null;
    }

    public IEnumerable<User?> GetAll()
    {
        var entities = _dbContext.Set<UserEntity>().AsEnumerable();

        var result = _mapper.Map<IEnumerable<User>>(entities);
        return result;
    }
    
    public async Task CreateAsync(UserCreate userCreate)
    {
        if (await IsExistsAsync(userCreate.TelegramId))
        {
            return;
        }
        
        var entity = _mapper.Map<UserEntity>(userCreate);
        entity.DateCreated = DateTime.Now;
        entity.IsActive = true;

        var entityEntry = await _dbContext.Set<UserEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    private async Task<bool> IsExistsAsync(long telegramId)
    {
        return await GetAsync(telegramId) is not null;
    }
}