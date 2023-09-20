using Domain.Entities.Auth;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Auth.Infrastructure;

public class UserRepository:RepositoryBase<User>
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}