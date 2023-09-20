using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

[Table("clients_role",Schema = "shop")]
public class ClientRole : ModelBase
{
    [Column("name")]
    public string Name { get; set; }
    [Column("active")]
    public bool Active { get; set; }
}