using Domain.Dto.Auth;
using Domain.Entities.Auth;

namespace EvoMarket.Auth.Service.Interfaces.ServiceInterfaces;

public interface IAuthService
{
    public ValueTask<UserDto> Registration(UserDto user, string otp);
    public ValueTask<bool> Login(UserDto user);
    public ValueTask<UserDto> RecoverPassword(UserDto user,string otp);
}