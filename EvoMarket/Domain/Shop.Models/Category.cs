using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Domain.Shop.Models;

[Table("categories")]
public class Category:ModelBase
{
    [Column("title")]
    public string Title { get; set; }
    [Column("image_url")]
    public string ImageUrl { get; set; }
}

