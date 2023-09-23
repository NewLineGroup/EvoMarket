using Domain.Entities.Auth;
using EvoMarket.WebCore.Interfaces;

namespace EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;

public interface IUserRepository:IRepositoryBase<User>
{ 
    public Task<User?> GetUserByEmailPassword(string userDtoEmail, string userDtoOtp);
}