using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

[Table("cart",Schema = "shop")]
public class Cart:ModelBase
{
    [Column("quantity")]
    public int Quantity { get; set; }
    
    [Column("price")]
    public decimal Price { get; set; }
}