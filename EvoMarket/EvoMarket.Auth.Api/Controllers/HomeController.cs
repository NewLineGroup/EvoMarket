using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Auth.Api.Controllers;
[ApiController]
[Route("/")]
public class HomeController: Controller
{
    public async Task<IActionResult> Index()
    {
        return base.View();
    }
}