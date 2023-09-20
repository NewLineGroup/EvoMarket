using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShop.Domain.Models;

[Table("user_devices")]
public class Device:ModelBase
{
    [Column("user_id")] public int UserId { get; set; }
    [Column("ip")] public string Ip { get; set; }
    [Column("device_name")] public string DeviceName { get; set; }
    [Column("last-log_date")] public DateTime LasLogDate { get; set; }
}