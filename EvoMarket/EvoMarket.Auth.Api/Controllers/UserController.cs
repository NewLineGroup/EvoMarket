using Domain.Dto.Auth;
using Domain.Entities.Auth;
using EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;
using EvoMarket.Auth.Service.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Auth.Api.Controllers;

[Controller]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
private ITokenService TokenService { get; set; }
    private IAuthService AuthService { get; set; }

    public UserController(IUserRepository repository, IAuthService authService, ITokenService tokenService) 
    {
        _userRepository = repository;
        AuthService = authService;
        TokenService = tokenService;
    }

    [HttpPost("create")]
    [Authorize]
    public async ValueTask<UserDto> CreateAsync(UserDto data)
    {
        User user = new User()
        {
            Email = data.Email,
            Otp = data.Otp,
            PasswordHashString = data.Password,
            Id = data.Id,
            ExpireDate = DateTime.Now
        };
         await _userRepository.CreatAsync(user);
         return data;
    }

    [HttpPut("update")]
    [Authorize]
    public async ValueTask<User> UpdateAsync(UserDto data)
    {
        User user = new User()
        {
            Email = data.Email,
            Otp = data.Otp,
            PasswordHashString = data.Password,
            Id = data.Id,
            UpdatedAt = DateTime.Now
        };
        return await _userRepository.UpdateAsync(user);
    }
    
    [HttpGet, AllowAnonymous]
    
    [Route("get-token")]
    public async Task<string> GetToken()
    {
        return TokenService.GetToken();
    }


    [HttpPost("registration")]
    [Authorize]
    public async void Registration([FromBody] UserDto userDto, [FromQuery] string otp)
    {
        var res = await AuthService.Registration(userDto, otp);
        if (res is not null)
        {
            Response.StatusCode = 200;
        }
    }
    
    [HttpPost("login")]
    [Authorize]
    public async void Login([FromBody] UserDto userDto)
    {
        var res = await AuthService.Login(userDto);
        if (res)
        {
            Response.StatusCode = 200;
        }
    }
    
    [HttpPost("recover-password")]
    [Authorize]
    public async void RecoverPassword([FromBody] UserDto userDto,string otp)
    {
        var res = await AuthService.RecoverPassword(userDto,otp);
        if (res is not null)
        {
            Response.StatusCode = 200;
        }
    }
    
    [HttpGet("get-all")]
    [Authorize]
    public async ValueTask<List<User>> GetAllAsync()
    {
       return  _userRepository.GetAllAsync().Result.ToList();
    }

    [HttpGet("get-by-id/{id:long}")]
    [Authorize]
    public async ValueTask<User> GetByIdAsync(long id)
        => await _userRepository.GetByIdAsync(id);
    
    [HttpDelete("delete/{id:long}")]
    [Authorize]
    public async ValueTask<User> DeleteAsync(long id)
        => await _userRepository.DeleteAsync(id);

}