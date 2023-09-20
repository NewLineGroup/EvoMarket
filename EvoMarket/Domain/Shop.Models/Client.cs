namespace Domain.Shop.Models;

public class Client : ModelBase
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string  Type { get; set; }

    public string? ProfilImage { get; set; }

    public long RoleId { get; set; }

    public double Rate { get; set; }

}