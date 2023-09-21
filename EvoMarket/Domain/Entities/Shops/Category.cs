using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Domain.Entities.Shops;

[Table("categories", Schema = "shop")]
public class Category : ModelBase
{
    [Column("title")] public string Title { get; set; }
    [Column("image_url")] public string ImageUrl { get; set; }
    public ICollection<FilterParam> FilterParams { get; set; }
    public ICollection<Product> Products { get; set; }
}