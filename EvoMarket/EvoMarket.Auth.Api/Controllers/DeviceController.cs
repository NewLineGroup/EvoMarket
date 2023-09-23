
using Domain.Entities.Auth;
using EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Auth.Api.Controllers;

[ApiController]
[Route("/divece")]
public class DeviceController : BaseController<Device>
{
    private readonly IDeviceRepository _repository;

    public DeviceController(IDeviceRepository repository) : base(repository)
    {
        _repository = repository;
    }

   
}