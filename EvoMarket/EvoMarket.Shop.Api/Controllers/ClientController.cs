using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;

[ApiController]
[Route("clients")]
public class ClientController:MyControllerBase<Client>
{
    private readonly IClientRepository _repository;

    public ClientController(IClientRepository repository) : base(repository)
    {
        _repository = repository;
    }
    
    [HttpPost("create")]
    public async ValueTask<Client> CreateAsync(ClientCreateDto data)
    {
        Client client = new Client
        {
            CreatedAt = DateTime.Now,
            FirstName = data.FirstName,
            LastName = data.LastName,
            PhoneNumber = data.PhoneNumber,
            Address = data.Address,
            ProfileImage = data.ProfileImage,
            Age = data.Age
        };
         return await _repository.CreatAsync(client);
    }
    [HttpPut("update")]
    public async ValueTask<Client> UpdateAsync(ClientUpdateDto data)
    {
        Client client = new Client
        {
            UpdatedAt = DateTime.Now,
            FirstName = data.FirstName,
            LastName = data.LastName,
            PhoneNumber = data.PhoneNumber,
            Address = data.Address,
            ProfileImage = data.ProfileImage,
            Age = data.Age
        };
        return await _repository.UpdateAsync(client);
    }
}