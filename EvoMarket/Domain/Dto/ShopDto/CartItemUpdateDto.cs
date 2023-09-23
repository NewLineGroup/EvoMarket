namespace Domain.Dto.ShopDto;

public class CartItemUpdateDto
{
    public long ProductId { get; set; }
    public long CartId { get; set; }
    public int Quantity { get; set; }
}