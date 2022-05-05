using AutoMapper;
using Xpymb.Telegram.Bot.Data.Entities;
using Xpymb.Telegram.Bot.Infrastructure.Entities;

namespace Xpymb.Telegram.Bot.Configuration;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, User>();
        CreateMap<User, UserEntity>();
        CreateMap<UserCreate, UserEntity>();
    }
}