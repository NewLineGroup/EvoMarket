namespace Domain.Dto.ShopDto;

public class ClientUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string? ProfileImage { get; set; }
    public int Age { get; set; }
}