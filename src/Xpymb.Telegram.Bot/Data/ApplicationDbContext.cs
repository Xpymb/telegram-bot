using Microsoft.EntityFrameworkCore;
using Xpymb.Telegram.Bot.Data.Entities;

namespace Xpymb.Telegram.Bot.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
            
    }

    public virtual DbSet<UserEntity> Users { get; set; }
    
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}