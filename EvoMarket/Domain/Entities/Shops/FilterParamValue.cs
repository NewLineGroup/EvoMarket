using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

[Table("filter_param_values", Schema = "shop")]
public class FilterParamValue : ModelBase
{
    public List<Category> Categories { get; set; }
    [Column("filter_param_id")] public long FilterParamId { get; set; }
    public FilterParam FilterParam { get; set; }
    [Column("value")] public string Value { get; set; }
}