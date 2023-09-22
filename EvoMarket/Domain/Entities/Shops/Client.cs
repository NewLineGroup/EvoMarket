using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Payment;

namespace Domain.Entities.Shops;

[Table("clients", Schema = "shop")]
public class Client : AuditableModelBase
{
    [Column("first_name")] public string FirstName { get; set; }
    [Column("last_name")] public string LastName { get; set; }
    [Column("phone_number")] public string PhoneNumber { get; set; }
    [Column("Address")] public string Address { get; set; }
    [Column("profile_image")] public string? ProfileImage { get; set; }
    [Column("rate")] public double Rate { get; set; }
    [Column("age")] public int Age { get; set; }
    [NotMapped]
    public List<Cart> Carts { get; set; }
    [NotMapped]
    public ICollection<ClientAccount> ClientAccounts { get; set; }
}