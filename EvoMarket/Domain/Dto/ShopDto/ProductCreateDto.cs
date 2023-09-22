namespace Domain.Dto.ShopDto;

public class ProductCreateDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public float Quantity { get; set; }
    public string ImageUrl { get; set; }
    public string ThumbImageUrl { get; set; }
    public float Rate { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int CategoryId { get; set; }
    public int MinAge { get; set; }
}