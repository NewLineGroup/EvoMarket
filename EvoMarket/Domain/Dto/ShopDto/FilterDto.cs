namespace Domain.Dto.ShopDto;

public class FilterDto
{
    public List<ResponsiveFilterDto> ResponsiveFilterDtos { get; set; }
    public decimal? Min { get; set; }
    public decimal? Max { get; set; }
}

public class ResponsiveFilterDto
{
    public string ParamName { get; set; }
    public string Value { get; set; } 
}