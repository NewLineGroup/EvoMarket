using Domain.Entities.Auth;
using EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Auth.Service.Repositories;

public class UserRepository:RepositoryBase<User>,IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public async Task<User?> GetUserByEmailPassword(string userDtoEmail, string userDtoOtp)
    {
        var users =await GetAllAsync();
        return  users.FirstOrDefault(user => user.Email == userDtoEmail && user.Otp == userDtoOtp);
    }
    
}