using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Auth;

[Table("devices")]
public class Device:Auditable
{
    [Required]
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("ip")] 
    public string Ip { get; set; }
    [Column("device_name")] 
    public string DeviceName { get; set; }
    [Column("last_login_date")]
    public DateTime LastLoginDate { get; set; }
    
    
}