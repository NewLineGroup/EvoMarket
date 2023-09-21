using Domain.Entities.Auth;
using EvoMarket.Auth.Infrastructure.Interfaces;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Auth.Infrastructure.Repositories;

public class UserRepository:RepositoryBase<User>,IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}