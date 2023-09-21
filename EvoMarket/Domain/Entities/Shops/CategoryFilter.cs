using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

[Table("category_filters", Schema = "shop")]
public class CategoryFilter : ModelBase
{
    
    [Column("category_id")] public long CategoryId { get; set; }
    public Category Category { get; set; }
    [Column("filter_param_id")] public long FilterPramId { get; set; }
    public FilterParam FilterParam { get; set; }
    [Column("value")] public string Value { get; set; }
    public ICollection<FilterParam> FilterParams { get; set; }
}