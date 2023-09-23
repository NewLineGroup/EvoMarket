using Domain.Entities.Shops;

namespace Domain.Dto.ShopDto;

public class CategoryFilterCreateDto
{
    public long CategoryId { get; set; }
    public long FilterParamId { get; set; }
    public string CategoryName { get; set; }
}