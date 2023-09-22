using Domain.Dto.Auth;
using Domain.Entities.Auth;
using EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Auth.Api.Controllers;

[ApiController]
[Route("/user")]
public class UserController : BaseController<User>
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository) : base(repository)
    {
        _repository = repository;
    }

    [HttpPost("create")]
    public async ValueTask<User> CreateAsync(UserDto data)
    {
        User user = new User()
        {
            Email = data.Email,
            Otp = data.Otp,
            PasswordHashString = data.Password,
            Id = data.Id,
            ExpireDate = DateTime.Now
        };
        return await _repository.CreatAsync(user);
    }

    [HttpPut("update")]
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
        return await _repository.CreatAsync(user);
    }
}