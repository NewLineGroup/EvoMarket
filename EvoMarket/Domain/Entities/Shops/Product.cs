using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

[Table("products", Schema = "shop")]
public class Product : ModelBase
{
    [Column("title")] public string Title { get; set; }
    [Column("price")] public decimal Price { get; set; }
    [Column("quantity")] public float Quantity { get; set; }
    [Column("image_url")] public string ImageUrl { get; set; }
    [Column("thumb_image_url")] public string ThumbImageUrl { get; set; }
    [Column("rate")] public float Rate { get; set; }
    [Column("discount_price")] public decimal? DiscountPrice { get; set; }
    [Column("category_id")] public int CategoryId { get; set; }
    [Column("min_age")] public int MinAge { get; set; }
}