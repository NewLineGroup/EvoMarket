
using Domain.Dto.Auth;
using Domain.Entities.Auth;
using EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Auth.Api.Controllers;

[Controller]
[Route("divece")]
public class DeviceController : ControllerBase
{
    private readonly IDeviceRepository _repository;

    public DeviceController(IDeviceRepository repository) 
    {
        _repository = repository;
    }
    [HttpPost("create")]
    [Authorize]
    public async ValueTask<User> CreateAsync([FromBody]Device data)
    {
       var res=await _repository.CreatAsync(data);
       if (res is not null)
       {
           Response.StatusCode = 200;
       }

       return null;
    }
    
    [HttpGet("get-all")]
    [Authorize]
    public async ValueTask<List<Device>> GetAllAsync()
    {
        return  _repository.GetAllAsync().Result.ToList();
    }

    [HttpGet("get-by-id/{id:long}")]
    [Authorize]
    public async ValueTask<Device> GetByIdAsync(long id)
        => await _repository.GetByIdAsync(id);
    
    [HttpDelete("delete/{id:long}")]
    [Authorize]
    public async ValueTask<Device> DeleteAsync(long id)
        => await _repository.DeleteAsync(id);
    
}