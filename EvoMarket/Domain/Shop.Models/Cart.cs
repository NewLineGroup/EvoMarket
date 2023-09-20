using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Shop.Models;

[Table("cart",Schema = "shop")]
public class Cart:ModelBase
{
    [Column("quantity")]
    public int Quantity { get; set; }
    [Column("price")]
    public decimal Price { get; set; }
}