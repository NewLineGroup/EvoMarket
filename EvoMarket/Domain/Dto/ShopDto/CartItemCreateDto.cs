namespace Domain.Dto.ShopDto;

public class CartItemCreateDto
{
    public long ProductId { get; set; }
    public long CartId { get; set; }
    public int Quantity { get; set; }
}