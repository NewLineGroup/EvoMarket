using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Models;
[Table("users")]
public class User:ModelBase
{
    [Column("email")] public string Email { get; set; }
    [Column("password_hash")] public string PasswordHash { get; set; }
    [Column("client_id")] public int ClientId { get; set; }
    [Column("otp")] public string? Otp { get; set; }
    [Column("expire_date")] public DateTime ExpireDate { get; set; }
}