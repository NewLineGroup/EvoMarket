using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Shop.Models;

[Table("clients",Schema = "shop")]
public class Client : ModelBase
{
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
    [Column("type")]
    public string  Type { get; set; }
    [Column("profil_image")]
    public string? ProfilImage { get; set; }
    [Column("role_id")]
    public long RoleId { get; set; }
    [Column("rate")]
    public double Rate { get; set; }

}