using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

[Table("carts", Schema = "shop")]
public class Cart : AuditableModelBase
{
    [Column("quantity")] public int Quantity { get; set; }

    [Column("price")] public decimal Price { get; set; }
    
    public ICollection<Product>? Products { get; set; }
}