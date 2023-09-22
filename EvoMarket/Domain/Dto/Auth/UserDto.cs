using Domain.Entities.Auth;

namespace Domain.Dto.Auth;

public class UserDto
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Otp { get; set; }
    public Device Device { get; set; }
}