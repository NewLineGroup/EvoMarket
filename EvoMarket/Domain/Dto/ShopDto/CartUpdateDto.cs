namespace Domain.Dto.ShopDto;

public class CartUpdateDto
{
    public decimal TotalAmount { get; set; }
    public int TotalCount { get; set; }
    public long ClientId { get; set; }
    public long TransactionId { get; set; }
    public bool Closed { get; set; }
}