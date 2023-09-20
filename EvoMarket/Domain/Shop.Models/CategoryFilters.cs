using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Shop.Models;

public class CategoryFilters:ModelBase
{
    
    [Column("category_id")]
    public long CategoryId { get; set; }
    [Column("filter_param_id")]
    public long FilterPramId { get; set; }
    [Column("value")]
    public string Value { get; set; }
    [NotMapped]
    public List<FilterParams> FilterParams { get; set; }
}