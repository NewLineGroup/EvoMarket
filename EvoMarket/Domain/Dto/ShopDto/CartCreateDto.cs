namespace Domain.Dto.ShopDto;

public class CartCreateDto
{
    public decimal TotalAmount { get; set; }
    public int TotalCount { get; set; }
    public long TransactionId { get; set; }
    
    public long ClientId { get; set; }
    
}