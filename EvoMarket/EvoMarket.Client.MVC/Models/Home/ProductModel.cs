namespace EvoMarket.Client.MVC.Models.Home;

public class ProductModel
{
    public string? Image { get; set; }
    public string Title { get; set; }
    public double Rate { get; set; }
    public decimal Price { get; set; }
    public double? Discount { get; set; }
}