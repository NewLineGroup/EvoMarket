using Domain.Dto.Auth;
using Domain.Entities.Auth;
using EvoMarket.Auth.Service.Interfaces;
using EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;
using EvoMarket.Auth.Service.Interfaces.ServiceInterfaces;
using EvoMarket.Auth.Service.Repositories;
using EvoMarket.Notification.Services.Interfaces;
using EvoMarket.Notification.Services.Services;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.Shop.Service.Services;

namespace EvoMarket.Auth.Service.Services;

public class AuthService:IAuthService
{
    private IDeviceRepository DeviceRepository { get; set; }
    private IDeviceService DeviceService { get; set; }
    private IUserRepository UserRepository { get; set; }
    private IClientService ClientService { get; set; }
    private INotificationService NotificationService { get; set; }
    private IHashService HashService { get; set; }

    public AuthService(IDeviceRepository deviceRepository, IDeviceService deviceService, IUserRepository userRepository, IClientService clientService, INotificationService notificationService, IHashService hashService)
    {
        DeviceRepository = deviceRepository;
        DeviceService = deviceService;
        UserRepository = userRepository;
        ClientService = clientService;
        NotificationService = notificationService;
        HashService = hashService;
    }
 
    public async ValueTask<UserDto> Registration(UserDto user, string otp,Device device)
    {
        var devices = await DeviceRepository.GetUserDevices(user.Id);
        
        if (user.Otp==otp&&devices.Count==0)
        {
            long id =await ClientService.GetNewClientId();
            string passwordHash = await HashService.HashClientPassword(user.Password);
           await UserRepository.CreatAsync(new User
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Email = user.Email,
                PasswordHashString =passwordHash,
                ClinetId = (int)id,
                Otp = otp,
                ExpireDate = DateTime.Now.AddMinutes(1)
            });
           return user;
        }
        else
            throw new Exception("Otp in not valid");
    }

    public async ValueTask<bool> Login(UserDto userDto,Device device)
    {
      var user= await UserRepository.GetUserByEmailPassword(userDto.Email, userDto.Otp);
      var devices = await DeviceRepository.GetUserDevices(userDto.Id);

      if (user is not null)
      {
          Device? foundDevice = await DeviceService.GetDeviceByDeviceName(device.DeviceName, device.Ip);
          if (foundDevice is not null)
          {
              string message =$"Access to your account was detected on {DateTime.Now}./n If it's not you, you can cancel the session";
              await NotificationService.SendMailAsync(userDto.Email, "Warning message", message);
          }
          return true;
      }

      return false;
    }

    public async ValueTask<UserDto> RecoverPassword(UserDto userDto, string otp)
    {
        if (userDto.Otp == otp)
        {
            var user =await UserRepository.GetByIdAsync(userDto.Id);
            user.PasswordHashString =await HashService.HashClientPassword(userDto.Password);
            await UserRepository.UpdateAsync(user);
            return userDto;
        }
        else
            throw new Exception("Otp in not valid");
    }
    
}