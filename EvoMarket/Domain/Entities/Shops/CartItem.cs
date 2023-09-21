using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

[Table("cart_items", Schema = "shop")]
public class CartItem : ModelBase
{
    [Column("product_id")] public long ProductId { get; set; }
    public Product Product { get; set; }
    [Column("cart_id")] public long CartId { get; set; }
    public Cart Cart { get; set; }
    [Column("quantity")] public int Quantity { get; set; }
}