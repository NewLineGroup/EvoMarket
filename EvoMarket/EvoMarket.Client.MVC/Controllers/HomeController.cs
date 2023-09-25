using EvoMarket.Client.MVC.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Client.MVC.Controllers;

public class HomeController : Controller
{
    public List<ProductModel> ProductModels = new List<ProductModel>()
    {
        new ProductModel()
        {
            Discount = 35,
            Image = "https://cdn4.buysellads.net/uu/1/81016/1609783206-authentic-260x200-variation-4.jpg",
            Price = 200,
            Rate = 4,
            Title = "Bootstrap"
        },
        new ProductModel()
        {
            Discount = 35,
            Image = "https://cdn4.buysellads.net/uu/1/81016/1609783206-authentic-260x200-variation-4.jpg",
            Price = 200,
            Rate = 4,
            Title = "Bootstrap"
        }
    };
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        
        return View(new HomeViewModel()
        {
            TopProducts = ProductModels
        });
    }
}